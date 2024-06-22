using UnityEngine;

namespace PersonalLibrary.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// GetComponent in GameObject or additionally, AddComponent if it doesn't exist yet.
        /// </summary>
        public static T Get<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
        }

        /// <summary>
        /// GetComponent in Parent GameObject or additionally, AddComponent if it doesn't exist yet.
        /// </summary>
        public static T GetInParent<T>(this GameObject gameObject) where T : Component
        {
            GameObject parent = gameObject.GetParent();
            return parent.GetComponent<T>() ?? parent.AddComponent<T>();
        }

        /// <summary>
        /// GetComponent in Children GameObjects or additionally, AddComponent to a newly created child GameObject if it doesn't exist yet.
        /// </summary>
        public static T GetInChildren<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponentInChildren<T>();
            if (component == null)
            {
                GameObject newGO = new();
                newGO.SetParent(gameObject);
                newGO.name = typeof(T).ToString();
                return newGO.AddComponent<T>();
            }
            else return component;
        }

        #region Set Parent
        /// <summary>
        /// Set Parent for GameObject.
        /// <param name="parent">parent</param>
        /// <param name="position">local position</param>
        /// <param name="scale">local scale</param>
        /// </summary>
        public static void SetParent(this GameObject gameObject, Transform parent, Vector3 position, Vector3 scale)
        {
            gameObject.transform.SetParent(parent);
            gameObject.transform.localPosition = position;
            gameObject.transform.localRotation = Quaternion.identity;
            gameObject.transform.localScale = scale;
        }

        /// <summary>
        /// Set Parent for GameObject.
        /// <param name="parent">parent</param>
        /// <param name="position">local position</param>
        /// </summary>
        public static void SetParent(this GameObject gameObject, Transform parent, Vector3 position)
        {
            gameObject.SetParent(parent, position, Vector3.one);
        }

        /// <summary>
        /// Set Parent for GameObject.
        /// <param name="parent">parent Transform</param>
        /// </summary>
        public static void SetParent(this GameObject gameObject, Transform parent)
        {
            gameObject.SetParent(parent, Vector3.zero, Vector3.one);
        }

        /// <summary>
        /// Set Parent for GameObject.
        /// <param name="parentGO">parent GameObject</param>
        /// <param name="position">local position</param>
        /// <param name="scale">local scale</param>
        /// </summary>
        public static void SetParent(this GameObject gameObject, GameObject parentGO, Vector3 position, Vector3 scale)
        {
            Transform parent = parentGO.transform;
            gameObject.SetParent(parent, position, scale);
        }

        /// <summary>
        /// Set Parent for GameObject.
        /// <param name="parentGO">parent</param>
        /// <param name="position">local position</param>
        /// </summary>
        public static void SetParent(this GameObject gameObject, GameObject parentGO, Vector3 position)
        {
            Transform parent = parentGO.transform;
            gameObject.SetParent(parent, position, Vector3.one);
        }

        /// <summary>
        /// Set Parent for GameObject.
        /// <param name="parentGO">parent Transform</param>
        /// </summary>
        public static void SetParent(this GameObject gameObject, GameObject parentGO)
        {
            Transform parent = parentGO.transform;
            gameObject.SetParent(parent, Vector3.zero, Vector3.one);
        }
        #endregion

        /// <summary>
        /// Set name for GameObject.
        /// <param name="name">GameObject name.</param>
        /// </summary>
        public static void SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
        }

        /// <summary>
        /// Get n-th level parent GameObject.
        /// <param name="parentLevel">Parent GameObject level in hierarchy.</param>
        /// </summary>
        public static GameObject GetParent(this GameObject gameObject, int parentLevel = 1)
        {
            Transform transform = gameObject.transform;
            for (int i = 0; i < parentLevel; i++)
            {
                transform = transform.parent;
            }
            return transform.gameObject;
        }

        /// <summary>
        /// Destroy all child gameobjects.
        /// </summary>
        public static void DestroyAllChildren(this GameObject gameObject)
        {
            Transform transform = gameObject.transform;
            foreach (Transform child in transform)
            {
                Object.Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// Destroy all child gameobjects in edit mode.
        /// Destroying an object in edit mode destroys it permanently.
        /// </summary>
        public static void DestroyImmedeateAllChildren(this GameObject gameObject)
        {
            Transform transform = gameObject.transform;
            while (transform.childCount > 0)
            {
                Object.DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
    }
}