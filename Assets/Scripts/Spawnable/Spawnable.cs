using UnityEngine;

using Lean.Pool;

namespace FlappyDaBurd
{
    public abstract class Spawnable : MonoBehaviour, IPoolable
    {
        #region Variable declaration
        // local
        [SerializeField] private bool isStationary = false; // FOR TESTING ONLY
        [SerializeField] private SO_SpawnableType spawnableType;
        private bool _isDoomed;

        // public
        public SO_SpawnableType Type => spawnableType;
        public bool isDoomed => _isDoomed;
        #endregion

        private void FixedUpdate()
        {
            if (!isStationary)
                Movement();
            //PerFixedUpdate();
        }

        #region IPoolable
        public virtual void OnSpawn()
        {
            _isDoomed = false;
        }
        public virtual void OnDespawn()
        {
            
        }
        #endregion

        #region Methods
        protected virtual void Movement() { }
        //protected virtual void PerFixedUpdate() { }

        public void IsDoomed()
        {
            _isDoomed = true;
        }
        #endregion
    }
}
