using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyDaBurd.Core
{
    public class Pipes : Obstacle
    {
        [SerializeField] Vector2 m_SpawnOffset;
        [SerializeField] float m_Speed;

        protected override void Movement()
        {
            m_Transform.position += m_Speed * Time.deltaTime * Vector3.left;
        }

        protected override Vector3 SetSpawnPoint()
        {
            float SpawnPointX = CameraPosition().x + HalfScreenWidth() + m_SpawnOffset.x;
            float SpawnPointY = Random.Range(CameraPosition().y - HalfScreenHeight() + m_SpawnOffset.y, CameraPosition().y + HalfScreenHeight() - m_SpawnOffset.y);
            return m_Transform.position = new Vector3(SpawnPointX, SpawnPointY, 0);
        }
    }
}
