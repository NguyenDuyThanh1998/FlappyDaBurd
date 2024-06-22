using UnityEngine;

/// <summary>
/// ScritableObject that holds Stats for Spawnables. 
/// </summary>
public abstract class SO_Spawnable : ScriptableObject
{
    public abstract Vector3 SpawnPosition();
    public abstract Vector3 SpawnRotation();
    public abstract Vector3 Increment();
}
