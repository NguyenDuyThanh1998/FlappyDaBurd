using UnityEngine;

namespace FlappyDaBurd
{
    public class Pipes : Obstacle
    {
        [SerializeField] float m_Gap = 4.4f;
        [SerializeField] Vector2 m_SpawnOffset = new Vector2(2, .7f);
        [SerializeField] float m_GroundOffset = 1.5f;
        [SerializeField] SO_ParallaxIndex Ground;

        protected override void OnEnable()
        {
            base.OnEnable();

            Ground = Resources.Load<SO_ParallaxIndex>("ScriptableObjects/Parallax/Parallax_Ground_00");
        }

        protected override void Movement()
        {
            m_Transform.position += Ground.speed * Time.fixedDeltaTime * Vector3.left;
        }

        protected override Vector3 SetSpawnPoint()
        {
            float SpawnPointX = CameraPosition().x + HalfScreenWidth() + m_SpawnOffset.x;
            float SpawnPointY = Random.Range(CameraPosition().y - HalfScreenHeight() + m_SpawnOffset.y + m_GroundOffset, CameraPosition().y + HalfScreenHeight() - m_SpawnOffset.y);
            return m_Transform.position = new Vector3(SpawnPointX, SpawnPointY, 0);
        }
    }
}
