using UnityEngine;

using PersonalLibrary.Utilities;

using static FlappyDaBurd.Datagram.Constant;

namespace FlappyDaBurd
{
    //
    public class Score : Spawnable
    {
        [SerializeField] private SO_Pipe pipeAsset; // SO_SpawnableAsset
        private int points;

        public SO_Pipe Asset => pipeAsset;
        public int Points => points;

        public void Initialize(SO_Pipe asset)
        {
            pipeAsset = asset;

            points = asset.Damage;
            transform.position = asset.SpawnPoint;
            transform.eulerAngles = asset.Rotation;
            //
        }

        protected override void Movement()
        {
            transform.position += pipeAsset.Increment() * Time.fixedDeltaTime;
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag(TAG.Flappy))
            {
                EventManager.Raise(new EventCollectablePickup(this));
            }
        }
    }
}
