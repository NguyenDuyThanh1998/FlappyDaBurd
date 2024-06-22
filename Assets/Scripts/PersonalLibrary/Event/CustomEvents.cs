namespace PersonalLibrary.Utilities
{
    /// <summary>
    /// When flappy collects consumable.
    /// </summary>
    public class EventCollectablePickup : CustomEvent
    {
        public FlappyDaBurd.Collectable obj;
        public int points;
    }

    /// <summary>
    /// When flappy hits an obstacle.
    /// </summary>
    public class EventObstacleHit : CustomEvent
    {
        public FlappyDaBurd.Obstacle obj;
        public int damage;
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
        public FlappyDaBurd.Pipes obj;
        public SO_Pipe asset;
    }
}
