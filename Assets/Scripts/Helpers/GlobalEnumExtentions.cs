using System;

namespace FlappyDaBurd.Core
{
    public static class GlobalEnumExtentions
    {
        public static Type GetSpawnableType(this ESpawnableType _spawnableType)
        {
            switch (_spawnableType)
            {
                case ESpawnableType.Collectable:
                    return typeof(ECollectableType);
                case ESpawnableType.Obstacle:
                    return typeof(EObstacleTpye);
                case ESpawnableType.None:
                    return null;
                default:
                    return null;
            }
        }

        public static Type GetCollectableType(this ECollectableType _collectableType)
        {
            switch (_collectableType)
            {
                case ECollectableType.Currency:
                    return typeof(ECurrencyType);
                case ECollectableType.Powerup:
                    return typeof(EPowerupType);
                case ECollectableType.None:
                    return null;
                default:
                    return null;
            }
        }
    }
}