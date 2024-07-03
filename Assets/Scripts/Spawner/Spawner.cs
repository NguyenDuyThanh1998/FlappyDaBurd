using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FlappyDaBurd
{
    public abstract class Spawner : MonoBehaviour
    {
        [Header("Spawnable")]
        [SerializeField] protected bool isSpawn = true; // FOR TESTING ONLY
        [SerializeField] protected Transform parent;

        [ContextMenu("Set up")]
        private void Awake()
        {
            GetResources();
            SetDefaults();
        }

        protected abstract void GetResources();

        protected virtual void SetDefaults()
        {
            if(!parent)
                parent = transform;
        }

        #region Methods
        /// <summary>
        /// Get specified Component from prefab.
        /// </summary>
        /// <typeparam name="T">Component Type.</typeparam>
        /// <param name="_path">Path to Prefab.</param>
        /// <returns>Component of type T, from prefab at given path.</returns>
        public T GetSpawnableFromPrefab<T>(string _path) where T : Spawnable
        {
            return Resources.Load<GameObject>(_path)    // Get the prefab from _path.
                            .GetComponent<T>();         // Get component from prefab.
        }

        /// <summary>
        /// Get specified Component from prefab.
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <param name="prefab">Prefab to get the Component from.</param>
        /// <returns>Component of type T, from prefab at given path.</returns>
        public T GetSpawnbleFromPrefab<T>(GameObject prefab) where T : Spawnable
        {
            return prefab.GetComponent<T>();
        }

        /// <summary>
        /// Get Prefab with Spawnable Component from path.
        /// </summary>
        /// <typeparam name="T">Type of Spawnable.</typeparam>
        /// <param name="_path">Path to desired prefab.</param>
        /// <returns>The prefab with specified Spawnable component.</returns>
        public GameObject GetSpawnablePrefab<T>(string _path) where T : Spawnable
        {
            var prefab = Resources.Load<GameObject>(_path);
#if UNITY_EDITOR
            if (prefab == null)
            {
                Debug.LogError("Check path to prefab " + prefab.name);
                return null;
            }
#endif
            var spawnable = prefab.GetComponent<T>();
            if (spawnable != null)
            {
                //Debug.Log("Loaded: " + prefab.name);
                return prefab;
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log("Prefab " + prefab.name + " doesn't contain component " + spawnable);
#endif
                return null;
            }
        }

        /// <summary>
        /// Get specified Asset from path.
        /// </summary>
        /// <typeparam name="T">Spawnable Asset Type.</typeparam>
        /// <param name="_path">Path to asset.</param>
        /// <returns>Spawnable Asset</returns>
        public T GetAssetReference<T>(string _path) where T : SO_SpawnableAsset
        {
            return Resources.Load<T>(_path);
        }
        #endregion
    }
}
