using UnityEngine;

namespace FlappyDaBurd
{
    public class Despawner : MonoBehaviour
    {
        [SerializeField] [ReadOnly] Collider2D[] m_Colliders;

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
                spawn.ResetSpawnable();
                //Debug.Log("object: " + GO.name);
            }
        }
    }
}
