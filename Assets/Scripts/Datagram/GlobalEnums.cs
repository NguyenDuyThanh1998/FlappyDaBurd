namespace FlappyDaBurd.Datagram
{
    /// <summary>
    /// Enum for Spawnable tpyes and subtypes
    /// </summary>
    #region Spawnable
    public enum ESpawnableType
    {
        None = -1,
        Collectable = 0,
        Obstacle = 1,
    }

    #region Collectable
    public enum ECollectableType
    {
        None = -1,
        Currency = 0,
        Powerup = 1,
    }

    public enum ECurrencyType
    {
        None = -1,
        Coin = 0,
        CoinBag = 1,
        Diamond = 2,
        CursedGem = 3,
    }

    public enum EPowerupType
    {
        None = -1,
        DoubleCurrency = 0,
        ShrinkSize = 1,
        Remove = 2,
        Diamond = 3,
        CursedGem = 4,
    }
    #endregion

    #region Obstacle
    public enum EObstacleTpye
    {
        None = -1,
        Pipes = 0,
        Bomb = 1,
        Enemy = 2,
    }

    public enum EEnemyType
    {
        None = -1,
        Flapper = 0,
        Hawk = 1,
        Eagle = 2,
    }
    #endregion
    #endregion

    /// <summary>
    /// Enum for Auio Sound Clips
    /// </summary>
    #region SoundID
    public enum ESoundID
    {
        None = -1,
        Play = 0,
        Pause = 1,
        Restart = 2,

        LifeUp = 3,
        LifeDown = 4,
        Death = 5,

        Collect = 6,
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    
}