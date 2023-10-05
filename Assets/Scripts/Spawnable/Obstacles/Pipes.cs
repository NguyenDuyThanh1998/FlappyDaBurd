using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyDaBurd.Core
{
    public class Pipes : Obstacle
    {
        [SerializeField] Vector2 m_SpawnOffset;
        [SerializeField] float m_GroundOffset;
        [SerializeField] SO_ParallaxIndex Ground;

        protected override void OnEnable()
        {
            base.OnEnable();

            Ground = Resources.Load<SO_ParallaxIndex>("ScriptableObjects/Parallax/Parallax_Ground_00");
        }

        protected override void Movement()
        {
            m_Transform.position += Ground.speed * Time.deltaTime * Vector3.left;
        }

        protected override Vector3 SetSpawnPoint()
        {
            float SpawnPointX = CameraPosition().x + HalfScreenWidth() + m_SpawnOffset.x;
            float SpawnPointY = Random.Range(CameraPosition().y - HalfScreenHeight() + m_SpawnOffset.y + m_GroundOffset, CameraPosition().y + HalfScreenHeight() - m_SpawnOffset.y);
            return m_Transform.position = new Vector3(SpawnPointX, SpawnPointY, 0);
        }
    }
}
