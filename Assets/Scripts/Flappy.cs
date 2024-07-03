using UnityEngine;

using Core;
using FlappyDaBurd.Datagram;
using static FlappyDaBurd.Datagram.Constant;

using PersonalLibrary.Utilities;
using PersonalLibrary.pUnity.pAttribute;

namespace FlappyDaBurd
{
    public class Flappy : Singleton<Flappy>
    {
        #region Variable Declaration
        // local
        [SerializeField, ReadOnly] Rigidbody2D m_RigidBody;
        [SerializeField, ReadOnly] Transform m_Transform;
        [SerializeField, ReadOnly] Animator m_Animator;

        [Space(10)]
        [SerializeField] SO_HitPoints m_HP;
        [SerializeField] Vector2 m_FlapPower;
        [SerializeField] Vector2 m_FallPower;

        // Sounds
        [SerializeField] ESoundID s_Collect = ESoundID.Collect;
        [SerializeField] ESoundID s_TakeHit = ESoundID.LifeDown;
        [SerializeField] ESoundID s_Death = ESoundID.Death;
        #endregion

        private void OnEnable()
        {
            EventManager.AddListener<EventCollectablePickup>(OnCollectablePickup);
            EventManager.AddListener<EventObstacleHit<Pipes>>(OnObstacleHit);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<EventCollectablePickup>(OnCollectablePickup);
            EventManager.RemoveListener<EventObstacleHit<Pipes>>(OnObstacleHit);
        }

        private void Awake()
        {
            Initialize();
        }

        void Update()
        {
            if (InputListener())
            {
                Flap();
            }
        }

        void FixedUpdate()
        {
            Fall();
        }

        [ContextMenu("Initialize")]
        void Initialize()
        {
            //InputListener();
            GetResources();
            SetDefaults();
            //GetStats();
        }

        void GetResources()
        {
            if (!m_RigidBody)
                m_RigidBody = GetComponent<Rigidbody2D>();
            if (!m_Animator)
                m_Animator = GetComponent<Animator>();

            if (!m_HP)
                m_HP = Resources.Load<SO_HitPoints>(PATH.FOLDER_RESOURCES + PATH.SO_HIT_POINTS + "SO_FlappyHP_Default");
        }

        public void SetDefaults()
        {
            m_Transform = transform;
            m_Transform.position = VECTOR3.DEFAULT_POSITION;
            m_Transform.eulerAngles = VECTOR3.DEFAULT_EULER_ANGLES;

            m_RigidBody.bodyType = RigidbodyType2D.Dynamic;
            SetPhysics(true);
            m_RigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;

            m_RigidBody.mass = 1f;
            m_RigidBody.gravityScale = 2.2f;

            m_RigidBody.drag = 0;
            m_RigidBody.angularDrag = 0.05f;
            m_RigidBody.velocity = Vector2.zero;
            //m_RigidBody.angularVelocity = 0;
        }

        public void SetPhysics(bool _state)
        {
            m_RigidBody.isKinematic = !_state;
        }

        bool InputListener()
        {
            bool MouseClicked = Input.GetMouseButtonDown(0);
            bool SpaceBarClicked = Input.GetKeyDown(KeyCode.Space);
            bool ScreenTapped = GetTouchInput();

            return MouseClicked || SpaceBarClicked || ScreenTapped;
        }

        bool GetTouchInput(TouchPhase phase = TouchPhase.Began)
        {
            return (Input.touchCount > 0 && Input.GetTouch(0).phase == phase);
        }

        void Flap()
        {
            m_RigidBody.velocity = Vector2.up * m_FlapPower;

            if (m_RigidBody.rotation > SINGLE.MAX_ANGLE)
            {
                m_RigidBody.rotation = SINGLE.MAX_ANGLE;
            }
            else
            {
                SetRotation(m_FlapPower);
            }
        }

        void Fall()
        {
            if (m_RigidBody.rotation < SINGLE.MIN_ANGLE)
            {
                m_RigidBody.rotation = SINGLE.MIN_ANGLE;
            }
            else
            {
                SetRotation(m_FallPower);
            }
        }

        float SetRotation(Vector2 _vector, float _index = SINGLE.ROTATIONAL_INDEX)
        {
            return m_RigidBody.rotation = m_RigidBody.velocity.y * _vector.magnitude * _index;
            //return m_Transform.rotation = Quaternion.Euler(0, 0, m_RigidBody.velocity.y * _vector.magnitude * _index);
        }

        public void PlayDeadAnimation()
        {

        }

        #region Animation
        const string DEAD = "_idle";
        const string ALIVE = "_slowFlap";
        const string FLY = "_quickFlap";
        string m_CachedAnim;
        void PlayAnimationByName(string _animation, float _duration = 0f)
        {
            //Debug.Log("Anim: " + m_CachedAnim);
            bool isSameAnim = m_CachedAnim == _animation;
            bool isLooping = m_Animator.GetCurrentAnimatorStateInfo(0).loop;
            if (isSameAnim && isLooping)
            {
                return;
            }
            else if (isSameAnim && !isLooping)
            {
                m_Animator.Rebind();
                m_Animator.PlayInFixedTime(_animation);
            }
            else
            {
                //m_Animator.Rebind();
                m_Animator.CrossFade(_animation, _duration);
            }
            m_CachedAnim = _animation;
        }
        #endregion

        //
        public void OnCollectablePickup(EventCollectablePickup e)
        {
#if UNITY_EDITOR
            Debug.Log("Picked up: " + e.collectable.GetType().Name);
#endif
            //DataManager.Instance.Inventory.Add(collectable);
            AudioManager.Instance.PlayEffect(s_Collect);
        }

        public void OnObstacleHit(EventObstacleHit<Pipes> e)
        {
#if UNITY_EDITOR
            Debug.Log("Obstacle hit: " + e.obstacle.GetType().Name);
#endif
            //var currentHP = DataManager.Instance.HealthPoints;
            var currentHP = m_HP.TakeHit(e.obstacle.Damage);
            AudioManager.Instance.PlayEffect(s_TakeHit);
            //UIManager.DisplayStats.Health = 0;

            if (currentHP < 1)
            {
#if UNITY_EDITOR
                Debug.Log("flappy dead");
#endif
                AudioManager.Instance.PlayEffect(s_Death);
                GameManager.Instance.GameOver();
            }
        }
    }
}
