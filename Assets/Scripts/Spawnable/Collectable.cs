using UnityEngine;

using Lean.Pool;
using PersonalLibrary.Utilities;

using FlappyDaBurd.Datagram;

namespace FlappyDaBurd
{
    public abstract class Collectable : Spawnable
    {
        protected int points = 1;

        #region Spawn
        public override void DoSpawn(Transform parent)
        {
            Initialize();
            LeanPool.Spawn(this, parent);
        }

        public override void DoDespawn()
        {
            if (isActiveAndEnabled)
            {
                LeanPool.Despawn(this);
            }
        }

        public override void OnSpawn()
        {
            GetStats();
            SpawnPosition();
            SpawnRotation();
        }

        public override void OnDespawn()
        {
            //
        }
        #endregion

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Constant.Str.FlappyTag))
            {
                EventManager.Raise(new EventCollectablePickup() { obj = this, points = points });
            }
        }
    }
}