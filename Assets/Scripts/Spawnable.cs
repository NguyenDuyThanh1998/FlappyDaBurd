using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyDaBurd.Core
{
    public abstract class Spawnable : MonoBehaviour
    {
        // local
        protected Transform m_Transform;
        protected Vector3 m_Position;
        protected Vector3 m_Scale;
        protected Vector3 m_EulerAngles;

        //protected Vector2 m_CameraPosition;
        //protected float m_HalfScreenWidth;
        //protected float m_HalfScreenHeight;

        // public
        public Vector3 Scale => m_Scale;
        public Vector3 Position => m_Position;
        public Vector3 EulerAngles => m_EulerAngles;

        protected virtual void Awake()
        {
            m_Transform = transform;

            if (Map.Instance != null)
            {
                m_Transform.SetParent(Map.Instance.transform);
            }
        }
        
        protected virtual void OnEnable()
        {
            SetDefaults();
            SetSpawnPoint();
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

        #region Abstract
        protected abstract Vector3 SetSpawnPoint();

        protected abstract void Movement();

        protected abstract void OnHit();

        protected abstract void ResetSpawnable();
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
