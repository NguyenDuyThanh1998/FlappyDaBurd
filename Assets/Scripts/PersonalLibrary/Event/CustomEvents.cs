namespace PersonalLibrary.Utilities
{
    /// <summary>
    /// When flappy collects consumable.
    /// </summary>
    public class EventCollectablePickup : CustomEvent
    {
        public readonly FlappyDaBurd.Spawnable collectable;

        public EventCollectablePickup(FlappyDaBurd.Spawnable _collectable)
        {
            collectable = _collectable;
        }
    }

    /// <summary>
    /// When flappy hits an obstacle.
    /// </summary>
    public class EventObstacleHit<T> : CustomEvent
    {
        public readonly T obstacle;

        public EventObstacleHit(T _obstacle)
        {
            obstacle = _obstacle;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EventButtonClick : CustomEvent
    {

    }

    /// <summary>
    /// When a Pipes prefab is spawned
    /// </summary>
    public class EventPipeSpawn : CustomEvent
    {
        public SO_Pipe asset;

        public EventPipeSpawn(SO_Pipe cachedAsset)
        {
            asset = cachedAsset;
        }
    }
}
