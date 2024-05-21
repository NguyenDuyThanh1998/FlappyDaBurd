using UnityEngine;
using Lean.Pool;
using PersonalLibrary.Utilities;

namespace FlappyDaBurd
{
    public abstract class Obstacle : Spawnable
    {
        protected int damage;

        public override void ResetSpawnable()
        {
            if (isActiveAndEnabled)
            {
                LeanPool.Despawn(gameObject);
            }
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag(Constants.Key.FlappyTag))
            {
                EventManager.Raise(new EventObstacleHit() { damage = damage });
            }
        }
    }
}
