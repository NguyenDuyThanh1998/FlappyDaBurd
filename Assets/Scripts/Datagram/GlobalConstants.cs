using UnityEngine;

namespace FlappyDaBurd.Datagram
{
    /// <summary>
    /// Global constants
    /// </summary>
    public static class Constant
    {
        #region Numbers
        // Int
        public partial class Num
        {
            public const int DefaultHealth = 1;
        }

        // Float
        public partial class Num
        {
            public const float someFloat = 6.9f;
        }
        #endregion

        #region Strings
        // Tags
        public partial class Str
        {
            public const string FlappyTag = "Flappy";
        }

        // Path
        public partial class Str
        {
            public const string PrefabFolder = "Assets/Prefabs/";
            public const string PipePrefab = "Objects/Spawnables/Obstacles/Pipes.prefab";
            public const string ScorePipePrefab = "Objects/Spawnables/Collectables/Score_pipe.prefab";

            public const string ResourceFolder = "Assets/Resources/";
            public const string SO_Background = "ScriptableObjects/Parallax/Background/";
            public const string SO_Ground = "ScriptableObjects/Parallax/Ground/";
            //public const string SO_SpawnStats = "ScriptableObjects/SpawnStats/";
            public const string SO_Pipes = "ScriptableObjects/SpawnStats/Obstacles/Pipes/";
        }
        #endregion

        #region Static Variables
        public static Vector2 CameraPosition
        {
            get => Camera.main.transform.position;
        }

        public static Vector2 ScreenSize
        {
            get => new Vector2(HalfScreenWidth * 2, HalfScreenHeight * 2);
        }

        public static float HalfScreenWidth
        {
            get => HalfScreenHeight * Camera.main.aspect;
        }

        public static float HalfScreenHeight
        {
            get => Camera.main.orthographicSize;
        }
        #endregion
    }
}
