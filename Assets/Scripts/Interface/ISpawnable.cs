using UnityEngine;

public interface ISpawnable
{
    public Vector3 GetSpawnPoint();
    //public Vector3 GetRotation();
    //public Vector3 GetScale();
    public Vector3 Increment();
}
