using UnityEngine;

using static FlappyDaBurd.Datagram.Constant;

[CreateAssetMenu(menuName = "Scriptable Objects/Spawnable Type", fileName = PATH.FOLDER_RESOURCES + PATH.SO_SPAWNABLE_TYPES + "New Spawnable Type", order = 1)]
public class SO_SpawnableType : ScriptableObject
{
    public bool isHarmful;
}
