using UnityEngine;
using Lean.Pool;
using Core.Audio;

namespace FlappyDaBurd
{
    public abstract class Collectable : Spawnable
    {
        [SerializeField] ESoundID m_CollectSound = ESoundID.Collect;

        // Const
        const string k_FlappyTag = "Flappy";

        public override void ResetSpawnable()
        {
            if (isActiveAndEnabled)
            {
                LeanPool.Despawn(gameObject);
            }
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag(k_FlappyTag))
            {
                OnHit();
            }
        }

        protected override void OnHit()
        {
            AudioManager.Instance.PlayEffect(m_CollectSound);
            Flappy.Instance.Collect(this);
        }
    }
}