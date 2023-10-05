using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

namespace FlappyDaBurd.Core
{
    public abstract class Obstacle : Spawnable
    {
        [SerializeField] ESoundID m_CollideSound = ESoundID.LifeDown;

        Renderer[] m_Renderers;

        // Const
        const string k_FlappyTag = "Flappy";
        const string k_Despawner = "Despawner";

        protected override void Awake()
        {
            base.Awake();

            m_Renderers = gameObject.GetComponents<Renderer>();
        }

        protected override void ResetSpawnable()
        {
            for (int i = 0; i < m_Renderers.Length; i++)
            {
                m_Renderers[i].enabled = true;
            }
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag(k_FlappyTag))
            {
                OnHit();
            }
            else if (col.name == k_Despawner)
            {
                OnDespawn();
            }
        }

        protected override void OnHit()
        {
            AudioManager.Instance.PlayEffect(m_CollideSound);
            Flappy.Instance.TakeHit();
        }

        public override void OnDespawn()
        {
            LeanPool.Despawn(this.gameObject);
        }
    }
}
