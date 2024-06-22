using UnityEngine;

namespace FlappyDaBurd
{
    //
    public class Score : Collectable
    {
        [SerializeField] private SO_Pipe pipe;

        public SO_Pipe Asset { set => pipe = value; }

        protected override void GetStats()
        {
            points = pipe.ScorePoints;
        }

        protected override Vector3 SpawnPosition()
        {
            return m_Transform.position = pipe.SpawnPosition() + pipe.ScoreOffset;
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
