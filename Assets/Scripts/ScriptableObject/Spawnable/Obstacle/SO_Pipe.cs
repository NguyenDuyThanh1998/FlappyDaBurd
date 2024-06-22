using UnityEngine;
using FlappyDaBurd.Datagram;

[CreateAssetMenu(menuName = "Scriptable Objects/Obstacle/Pipe", fileName = Constant.Str.ResourceFolder + Constant.Str.SO_Pipes + "Pipes_")]
public class SO_Pipe : SO_Obstacle
{
    [SerializeField] Vector3 spawnOffset = new Vector3(2, .7f, 0);
    [SerializeField] Vector3 scoreOffset = new Vector3(1.1f, 0, 0);
    [SerializeField] int scorePoints = 1;
    [SerializeField] float gap = 4.4f;
    [SerializeField] float groundOffset = 1.5f;
    [SerializeField] SO_ParallaxIndex ground;

    public Vector3 ScoreOffset => scoreOffset;
    public int ScorePoints => scorePoints;

    private void OnEnable()
    {
        if (!ground)
            ground = Resources.Load<SO_ParallaxIndex>(Constant.Str.SO_Ground + "Parallax_Ground_00");
    }

    public override Vector3 SpawnPosition()
    {
        float SpawnPointX = Constant.CameraPosition.x + Constant.HalfScreenWidth + spawnOffset.x;
        float SpawnPointY = Random.Range(Constant.CameraPosition.y - Constant.HalfScreenHeight + spawnOffset.y + groundOffset, Constant.CameraPosition.y + Constant.HalfScreenHeight - spawnOffset.y);
        var result = new Vector3(SpawnPointX, SpawnPointY, 0);
        return result;
    }

    public override Vector3 SpawnRotation()
    {
        return Vector3.zero;
    }

    public override Vector3 Increment()
    {
        return ground.Speed  * Vector3.left;
    }
}
