using UnityEngine;

/// <summary>
/// ScritableObject that holds Stats for Spawnables. 
/// </summary>
public abstract class SO_SpawnableAsset : ScriptableObject
{
    public abstract void Init();

    public T Copy<T>() where T : SO_SpawnableAsset
    {
        var instance = Instantiate(this);   // Create instance.
        instance.Init();                    // Init instance.
        return instance as T;
    }
}
