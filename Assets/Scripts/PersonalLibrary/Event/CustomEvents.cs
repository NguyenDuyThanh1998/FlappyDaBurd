using PersonalLibrary.Utilities;

/// <summary>
/// When flappy collects consumable.
/// </summary>
public class EventCollectablePickup : CustomEvent
{
    public FlappyDaBurd.Collectable collectable;
}

/// <summary>
/// When flappy hits an obstacle.
/// </summary>
public class EventObstacleHit : CustomEvent
{
    public int damage;
}

/// <summary>
/// 
/// </summary>
public class CustomEvent_03 : CustomEvent
{

}