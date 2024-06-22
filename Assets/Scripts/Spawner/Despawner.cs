using UnityEngine;
using PersonalLibrary.pUnity.pAttribute;

namespace FlappyDaBurd
{
    public class Despawner : MonoBehaviour
    {
        [SerializeField, ReadOnly] Collider2D[] m_Colliders;

        [ContextMenu("Set Child colliders as Trigger")]
        private void Start()
        {
            m_Colliders = GetComponentsInChildren<Collider2D>();
            foreach (var col in m_Colliders)
            {
                col.isTrigger = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Spawnable spawn = collision.transform.GetComponentInParent<Spawnable>();
            if (spawn)
            {
                spawn.DoDespawn();
#if UNITY_EDITOR
                //Debug.Log("Despawn: " + spawn.gameObject.name);
                Debug.Log("Despawn: " + spawn.GetType().Name);
#endif
            }
        }
    }
}
