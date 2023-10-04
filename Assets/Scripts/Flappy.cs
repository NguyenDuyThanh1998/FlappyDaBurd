using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyDaBurd.Core
{
    public class Flappy : Singleton<Flappy>
    {
        #region Variable Declaration
        // local
        [SerializeField] Rigidbody2D m_RigidBody;
        [SerializeField] Transform m_Transform;

        [SerializeField] Vector2 m_FlapPower;
        [SerializeField] Vector2 m_FallPower;

        // Const
        const float MAX_ANGLE = 42;
        const float MIN_ANGLE = -69;
        const float ROTATIONAL_INDEX = .69f;
        readonly Vector3 DEFAULT_POSITION = Vector3.left * 1.3f;
        readonly Vector3 DEFAULT_EULER_ANGLES = Vector3.zero;
        #endregion

        private void Awake()
        {
            Initialize();
        }

        [ContextMenu("Initialize")]
        void Initialize()
        {
            //InputListener();
            SetDefaultValues();
            SetupFlappy();
        }

        void SetDefaultValues()
        {
            m_Transform = transform;
            m_Transform.position = DEFAULT_POSITION;
            m_Transform.eulerAngles = DEFAULT_EULER_ANGLES;
        }

        void SetupFlappy()
        {
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

        void OnEnable()
        {
            //
        }

        void Update()
        {
            if (InputListener())
            {
                Flap();
            }
            //else
            //{
            //    Fall();
            //}
        }

        void FixedUpdate()
        {
            Fall();
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
                m_Transform.rotation = Quaternion.Euler(0, 0, m_RigidBody.velocity.y * RotationalSpeed(m_FlapPower));
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
                //m_RigidBody.rotation -= RotationalSpeed(m_FallPower);
                m_Transform.rotation = Quaternion.Euler(0, 0, m_RigidBody.velocity.y * RotationalSpeed(m_FallPower));
            }
        }

        float RotationalSpeed(Vector2 _vector, float _index = ROTATIONAL_INDEX)
        {
            Vector2 x = Vector2.up * _vector;
            Vector2 y = Vector2.right * _vector;
            return Vector2.Distance(x, y) * _index;
        }

        public void PlayDeadAnimation()
        {

        }

        //
        public void Collect(Collectable _collectable)
        {

        }

        public void TakeHit(int _damage = 1)
        {
            if (DataManager.Instance.HealthPoints < 1)
            {
                GameManager.Instance.GameOver();
            }
            else
            {
                DataManager.Instance.HealthPoints -= _damage;
            }
        }
    }
}
