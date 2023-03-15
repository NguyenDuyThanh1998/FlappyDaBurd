using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyDaBurd.Core
{
    public abstract class Spawnable : MonoBehaviour
    {
        Transform m_Transform;
        Vector3 m_Position;
        Vector3 m_Scale;
        Vector3 m_EulerAngles;

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
        }
        
        void SetDefaults()
        {
            m_Transform = transform;
            m_Scale = m_Transform.localScale;
            m_Position = m_Transform.position;
            m_EulerAngles = m_Transform.eulerAngles;
        }

        public virtual void ResetSpawnable()
        {
            // Override this for each type of Spawnable.
        }
    }
}
