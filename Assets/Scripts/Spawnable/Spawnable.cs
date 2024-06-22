using UnityEngine;

using Lean.Pool;

namespace FlappyDaBurd
{
    public abstract class Spawnable : MonoBehaviour, IPoolable
    {
        // local
        protected Transform m_Transform;
        protected Vector3 m_Position;
        protected Vector3 m_EulerAngles;
        protected Vector3 m_Scale;

        // public
        public Vector3 Position => m_Position;
        public Vector3 EulerAngles => m_EulerAngles;
        public Vector3 Scale => m_Scale;

        [ContextMenu("Set up")]
        private void Awake()
        {
            SetDefaults();
        }

        private void FixedUpdate()
        {
            Movement();
            //PerFixedUpdate();
        }

        #region Spawn states
        public abstract void DoSpawn(Transform parent);
        public abstract void DoDespawn();

        public abstract void OnSpawn();
        public abstract void OnDespawn();
        #endregion

        #region Spawnable aspects
        protected virtual void GetStats() { }

        protected abstract Vector3 SpawnPosition();

        protected abstract Vector3 SpawnRotation();

        protected abstract void Movement();
        #endregion

        #region Methods
        protected virtual void Initialize() { }
        protected virtual void SetDefaults()
        {
            m_Transform = transform;
            m_Scale = m_Transform.localScale;
            m_Position = m_Transform.position;
            m_EulerAngles = m_Transform.eulerAngles;
        }
        
        protected virtual void PerFixedUpdate() { }
        #endregion
    }
}
