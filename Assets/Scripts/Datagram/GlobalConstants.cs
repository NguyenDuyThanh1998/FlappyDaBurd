using UnityEngine;

namespace FlappyDaBurd.Datagram
{
    /// <summary>
    /// Global constants
    /// </summary>
    public static class Constant
    {
        #region Numbers
            #region Integer
        // System.Int16 - short
        public class INT16
        {
            public const short SOME_SHORT = 0;
        }

        // System.Int32 - int
        public class INT32
        {
            public const int DEFAULT_HEALTH = 1;
        }

        // System.Int64 - long
        public class INT64
        {
            public const long SOME_LONG = 2;
        }
            #endregion

            #region Float
        // System.Single - float
        public static class SINGLE
        {
            public const float SOME_SINGLE = 6.9f;
            public const float MAX_ANGLE = 42;
            public const float MIN_ANGLE = -69;
            public const float ROTATIONAL_INDEX = .69f;
        }

        // System.Double - double
        public class DOUBLE
        {
            public const double SOME_DOUBLE = 9.6f;
        }
            #endregion
        #endregion

        #region Vectors
        // Vector2
        public class VECTOR2
        {
            public static readonly Vector2 SOME_VECTOR2 = new Vector2(0, 0);
        }

        // Vector3
        public class VECTOR3
        {
            public static readonly Vector3 SOME_VECTOR3 = new Vector3(0, 0, 0);
            public static readonly Vector3 DEFAULT_POSITION = new Vector3(-3.5f, 0, 0); // Default Flappy position.
            public static readonly Vector3 DEFAULT_EULER_ANGLES = new Vector3(0, 0, 0); // Default Flappy euler angles.
        }

        // Vector4
        public class VECTOR4
        {
            public static readonly Vector4 SOME_VECTOR2 = new Vector4(0, 0, 0, 0);
        }
        #endregion

        #region Strings
        public static class TAG
        {
            public const string Flappy = "Flappy";
        }

        public static class PATH
        {
            // Folder
            public const string FOLDER_PREFAB = "Assets/Prefabs/";
            public const string FOLDER_RESOURCES = "Assets/Resources/";

            // Prefab
            public const string PREFAB_PIPE = "Prefabs/Spawnables/Pipes";
            public const string PREFAB_SCORE_PIPE = "Prefabs/Spawnables/Score_pipe";

            // Scriptable Objects
            public const string SO_HIT_POINTS = "ScriptableObjects/HitPoints/";
            public const string SO_BACKGROUND = "ScriptableObjects/Parallax/Background/";
            public const string SO_GROUND = "ScriptableObjects/Parallax/Ground/";
            public const string SO_SPAWNABLE_TYPES = "ScriptableObjects/SpawnableTypes/";
            public const string SO_PIPES = "ScriptableObjects/SpawnableAssets/Pipes/";
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
