using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FlappyDaBurd
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected bool isSpawn = true; // FOR TESTING ONLY
        [SerializeField] protected Transform parent;

        [ContextMenu("Set up")]
        private void Awake()
        {
            SetDefaults();
            LoadSpawnable();
            LoadAsset();
            Initialize();
        }

        protected virtual void SetDefaults()
        {
            if(!parent)
                parent = transform;
        }

        protected abstract void LoadSpawnable();
        protected virtual void LoadAsset() { }
        public virtual void Initialize() { }

        #region Methods
        protected Spawnable GetComponentFromPrefab(string _path)
        {
            var _type   = typeof(GameObject);
            var _prefab = (GameObject)AssetDatabase.LoadAssetAtPath(_path, _type);
            return _prefab.GetComponent<Spawnable>();
        }
        #endregion

        //#region Spawn overloads
        //public virtual void Spawn(Spawnable _spawnable) { }
        //public virtual void Spawn(Spawnable[] _spawnables) { }

        //public virtual void Spawn(Obstacle _obstacle) { }
        //public virtual void Spawn(Collectable _collectable) { }
        //public virtual void Spawn(Obstacle _obstacle, Collectable _collectable) { }
        //public virtual void Spawn(Obstacle[] _obstacles, Collectable[] _collectables) { }
        //#endregion
    }
}
