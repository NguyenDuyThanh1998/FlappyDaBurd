using UnityEngine;

using PersonalLibrary.pUnity.pAttribute;
using static FlappyDaBurd.Datagram.Constant;

[CreateAssetMenu(menuName = "Scriptable Objects/Spawnable Asset/Pipe", fileName = PATH.FOLDER_RESOURCES + PATH.SO_PIPES + "Pipes_", order = 10)]
public class SO_Pipe : SO_SpawnableAsset, ISpawnable
{
    #region Variable declaration
    // local
    [Header("Pipe Data")]
    [SerializeField] int damage = 1;
    [SerializeField] int scorePoints = 1;

    [SerializeField] Vector3 spawnPoint;
    [SerializeField] Vector3 rotation = Vector3.zero;
    [SerializeField] Vector3 scale = new Vector3(.65f, .65f, .65f);

    [Header("Ground")]
    [SerializeField] SO_ParallaxIndex ground;
    [SerializeField] float groundOffset = 1.5f;

    // public accessor
    public int Damage => damage;
    public int ScorePoints => scorePoints;

    public Vector3 SpawnPoint => spawnPoint;
    public Vector3 Rotation => rotation;
    public Vector3 Scale => scale;
    #endregion

    private void OnEnable()
    {
        LoadResources();
    }

    public override void Init()
    {
        GetSpawnPoint();
    }

    #region ISpawnable
    public Vector3 GetSpawnPoint()
    {
        var SpawnPointX = CameraPosition.x + HalfScreenWidth + GapSize().x / 2;
        var SpawnPointY = Random.Range(CameraPosition.y - HalfScreenHeight + GapSize().y / 2 + groundOffset, CameraPosition.y + HalfScreenHeight - GapSize().y / 2);
        return spawnPoint = new Vector3(SpawnPointX, SpawnPointY, 0);
    }

    public Vector3 Increment()
    {
        return ground.Speed * Vector3.left;
    }
    #endregion

    #region Methods
    private void LoadResources()
    {
        if (!ground)
            ground = Resources.Load<SO_ParallaxIndex>(PATH.SO_GROUND + "Parallax_Ground_00");
    }

    private Vector2 GapSize()
    {
        //TODO: make this function take parameters to give appropriate gapsize for better polymorphism.
        float gapX = 2.166667f * scale.x; // 2.166667f is the Width of a single pipe Sprite.
        float gapY = 2.2f * 2 * scale.y; // 2.2f is single pipe displacement.
        return new Vector2(gapX, gapY);
    }
    #endregion
}
