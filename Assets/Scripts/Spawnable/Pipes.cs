using UnityEngine;

using PersonalLibrary.Utilities;

using static FlappyDaBurd.Datagram.Constant;

namespace FlappyDaBurd
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Pipes : Spawnable
    {
        [SerializeField] private SO_Pipe pipeAsset; // FOR TESTING ONLY
        private int damage;

        public SO_Pipe Asset => pipeAsset;
        public int Damage => damage;

        public void Initialize(SO_Pipe asset)
        {
            pipeAsset = asset;

            damage = asset.Damage;
            transform.position = asset.SpawnPoint;
            transform.eulerAngles = asset.Rotation;
            transform.localScale = asset.Scale;
        }

        protected override void Movement()
        {
            transform.position += pipeAsset.Increment() * Time.fixedDeltaTime;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(TAG.Flappy))
            {
                EventManager.Raise(new EventObstacleHit<Pipes>(this));
            }
        }
    }
}
