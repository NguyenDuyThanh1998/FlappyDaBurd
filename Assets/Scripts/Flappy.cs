using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyDaBurd.Core
{
    public class Flappy : Singleton<Flappy>
    {
        #region Variable Declaration
        // local
        [SerializeField] bool m_IsFlapping;
        [SerializeField] Rigidbody2D m_RigidBody;

        [SerializeField] Transform m_Transform;

        [SerializeField] float m_FlapPower;
        [SerializeField] float m_FlapAngle;
        [SerializeField] float m_FallAngle;

        // Const
        readonly float MAX_ANGLE = 35;
        readonly float MIN_ANGLE = -69;
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
            InputListener();
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
            m_RigidBody.gravityScale = 1.8f;

            m_RigidBody.drag = 0;
            m_RigidBody.angularDrag = 0.05f;
            m_RigidBody.velocity = Vector2.zero;
            m_RigidBody.angularVelocity = 1;
        }

        public void SetPhysics(bool _state)
        {
            m_RigidBody.isKinematic = !_state;
        }

        void InputListener()
        {
            bool MouseClicked = Input.GetMouseButtonDown(0);
            bool SpaceBarClicked = Input.GetKeyDown(KeyCode.Space);
            bool ScreenTapped = GetTouchInput();

            m_IsFlapping = MouseClicked || SpaceBarClicked || ScreenTapped;
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

        private void OnEnable()
        {
            //
        }

        private void Update()
        {
            InputListener();
            if (m_IsFlapping)
            {
                Flap();
            }
            else
            {
                Fall();
            }
        }

        void Flap()
        {
            m_RigidBody.velocity = Vector2.up * m_FlapPower;

            if (m_RigidBody.rotation < MAX_ANGLE)
            {
                m_RigidBody.rotation += m_FlapAngle * m_RigidBody.angularVelocity;
            }
            /*else
                m_RigidBody.angularVelocity = 2f;*/
        }

        void Fall()
        {
            if (m_RigidBody.rotation > MIN_ANGLE)
            {
                m_RigidBody.rotation -= m_FallAngle * m_RigidBody.angularVelocity;
            }
        }

        public void PlayDeadAnimation()
        {

        }
    }
}
