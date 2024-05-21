using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using PersonalLibrary.Utilities;

namespace FlappyDaBurd
{
    public class Flappy : Singleton<Flappy>
    {
        #region Variable Declaration
        // local
        [SerializeField] Rigidbody2D m_RigidBody;
        [SerializeField] Transform m_Transform;
        [SerializeField] Animator m_Animator;

        [SerializeField] Vector2 m_FlapPower;
        [SerializeField] Vector2 m_FallPower;

        // Sounds
        [SerializeField] ESoundID s_Collect = ESoundID.Collect;
        [SerializeField] ESoundID s_TakeHit = ESoundID.LifeDown;
        [SerializeField] ESoundID s_Death   = ESoundID.Death;

        // Const
        const float MAX_ANGLE = 42;
        const float MIN_ANGLE = -69;
        const float ROTATIONAL_INDEX = .69f;
        readonly Vector3 DEFAULT_POSITION = new Vector3(-3.5f, 0, 0);
        readonly Vector3 DEFAULT_EULER_ANGLES = Vector3.zero;
        #endregion

        private void OnEnable()
        {
            EventManager.AddListener<EventCollectablePickup>(OnCollectablePickup);
            EventManager.AddListener<EventObstacleHit>(OnObstacleHit);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<EventCollectablePickup>(OnCollectablePickup);
            EventManager.RemoveListener<EventObstacleHit>(OnObstacleHit);
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
            SetDefaultValues();
            SetupFlappy();
        }

        public void SetDefaultValues()
        {
            m_Transform = transform;
            m_Transform.position = DEFAULT_POSITION;
            m_Transform.eulerAngles = DEFAULT_EULER_ANGLES;
        }

        void SetupFlappy()
        {
            if (!m_Animator)
                m_Animator = GetComponent<Animator>();
            if (!m_RigidBody)
                m_RigidBody = GetComponent<Rigidbody2D>();
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

        bool GetTouchInput()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                return true;
            }
            else 
                return false;
        }

        void Flap()
        {
            m_RigidBody.velocity = Vector2.up * m_FlapPower;

            if (m_RigidBody.rotation > MAX_ANGLE)
            {
                m_RigidBody.rotation = MAX_ANGLE;
            }
            else
            {
                SetRotation(m_FlapPower);
            }

        }

        void Fall()
        {
            if (m_RigidBody.rotation < MIN_ANGLE)
            {
                m_RigidBody.rotation = MIN_ANGLE;
            }
            else
            {
                SetRotation(m_FallPower);
            }
        }

        float SetRotation(Vector2 _vector, float _index = ROTATIONAL_INDEX)
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
        public void OnCollectablePickup(EventCollectablePickup collectable)
        {
            //DataManager.Instance.Inventory.Add(collectable);
            AudioManager.Instance.PlayEffect(s_Collect);
        }

        public void OnObstacleHit(EventObstacleHit obstacle)
        {
            var currentHP = DataManager.Instance.HealthPoints;
            currentHP -= obstacle.damage;
            AudioManager.Instance.PlayEffect(s_TakeHit);

            if (currentHP < 1)
            {
                GameManager.Instance.GameOver();
                //UIManager.DisplayStats.Health = 0;
                AudioManager.Instance.PlayEffect(s_Death);
            }
        }
    }
}
