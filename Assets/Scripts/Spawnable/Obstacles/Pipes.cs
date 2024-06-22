using UnityEngine;

namespace FlappyDaBurd
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Pipes : Obstacle
    {
        [SerializeField] private SO_Pipe pipe;
        private Spawner_Pipe spawner;

        public SO_Pipe Asset { set => pipe = value; }

        protected override void Initialize()
        {
            spawner.Initialize();
        }

        protected override void GetStats()
        {
            damage = pipe.Damage;
        }

        protected override Vector3 SpawnPosition()
        {
            return m_Transform.position = pipe.SpawnPosition();
        }

        protected override Vector3 SpawnRotation()
        {
            return m_Transform.eulerAngles = pipe.SpawnRotation();
        }

        protected override void Movement()
        {
            m_Transform.position += pipe.Increment() * Time.fixedDeltaTime;
        }
    }
}
