using UnityEngine;

using Lean.Pool;
using PersonalLibrary.pUnity.pAttribute;

namespace FlappyDaBurd
{
    public class Despawner : MonoBehaviour
    {
        [SerializeField, ReadOnly] private Collider2D[] colliders;
        [SerializeField] private float delay = 0.0f; // despawn delay.

        [ContextMenu("Set Child colliders as Trigger")]
        private void Start()
        {
            colliders = GetComponentsInChildren<Collider2D>();
            foreach (var col in colliders)
            {
                SetTrigger(col);
            }
        }

        private void SetTrigger(Collider2D col, bool target = true)
        {
            if (col.isTrigger != target)
                col.isTrigger = target;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var spawnable = collision.GetComponentInParent<Spawnable>();
            if (spawnable.isActiveAndEnabled && !spawnable.isDoomed)
            {
                spawnable.IsDoomed();
                LeanPool.Despawn(spawnable, delay);
#if UNITY_EDITOR
                //Debug.Log("Despawn: " + spawn.gameObject.name);
                Debug.Log("Despawn: " + spawnable.GetType().Name);
#endif
            }
        }
    }
}
