using UnityEngine;
using Lean.Pool;
using Core.Audio;

namespace FlappyDaBurd
{
    public abstract class Obstacle : Spawnable
    {
        [SerializeField] ESoundID m_CollideSound = ESoundID.LifeDown;

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
            AudioManager.Instance.PlayEffect(m_CollideSound);
            Flappy.Instance.TakeHit();
        }
    }
}
