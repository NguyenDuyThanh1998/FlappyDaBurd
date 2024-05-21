using UnityEngine;
using Lean.Pool;

namespace FlappyDaBurd
{
    public abstract class Spawnable : MonoBehaviour, IPoolable
    {
        // local
        protected Transform m_Transform;
        protected Vector3 m_Position;
        protected Vector3 m_Scale;
        protected Vector3 m_EulerAngles;

        // public
        public Vector3 Scale => m_Scale;
        public Vector3 Position => m_Position;
        public Vector3 EulerAngles => m_EulerAngles;

        // const
        //protected const string k_FlappyTag = "Flappy";

        protected virtual void Awake()
        {
            //
        }
        
        protected virtual void OnEnable()
        {
            SetDefaults();
        }

        protected virtual void FixedUpdate()
        {
            Movement();
            //PerFixedUpdate();
        }
        
        void SetDefaults()
        {
            m_Transform = transform;
            m_Scale = m_Transform.localScale;
            m_Position = m_Transform.position;
            m_EulerAngles = m_Transform.eulerAngles;
        }

        public virtual void OnSpawn()
        {
            SetSpawnPoint();
        }

        public virtual void OnDespawn() { }


        #region Abstract
        protected abstract Vector3 SetSpawnPoint();

        protected abstract void Movement();

        public abstract void ResetSpawnable();
        #endregion

        #region Methods
        protected Vector2 CameraPosition()
        {
            return Camera.main.transform.position;
        }

        protected float HalfScreenWidth()
        {
            return HalfScreenHeight() * Camera.main.aspect;
        }

        protected float HalfScreenHeight()
        {
            return Camera.main.orthographicSize;
        }
        #endregion
    }
}
