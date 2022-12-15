/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    public static float PaddleMoveUnitsPerSecond
    {
        get
        {
            return configurationData.PaddleMoveUnitsPerSecond;
        }
    }

    public static float BallMaxSpeed
    {
        get
        {
            return configurationData.BallMaxSpeed;
        }
    }

    public static float BallImpulseForce
    {
        get
        {
            return configurationData.BallImpulseForce;
        }
    }

    public static float TopBlockSpawnLocation
    {
        get
        { return configurationData.TopBlockSpawnLocation; }
    }
    public static float BottomBlockSpawnLocation
    {
        get
        { return configurationData.BottomBlockSpawnLocation; }
    }

    public static float MinBallSpawnTime
    {
        get { return configurationData.MinSpawnSeconds; }
    }
    public static float MaxBallSpawnTime
    {
        get { return configurationData.MaxSpawnSeconds; }
    }

    public static int BallsPerGame
    {
        get { return configurationData.BallsPerGame; }
    }

    public static int StandardBlockWorth
    {
        get { return configurationData.StandardBlockWorth; }
    }

    public static int LongBlockWorth
    {
        get { return configurationData.LongBlockWorth; }
    }

    public static int BonusBlockWorth
    {
        get { return configurationData.BonusBlockWorth; }
    }

    public static int EffectBlockWorth
    {
        get { return configurationData.EffectBlockWorth; }
    }

    public static float StandardBlockSpawnChance
    {
        get { return configurationData.StandardBlockSpawnChance; }
    }

    public static float LongBlockSpawnChance
    {
        get { return configurationData.LongBlockSpawnChance; }
    }

    public static float BonusBlockSpawnChance
    {
        get { return configurationData.BonusBlockSpawnChance; }
    }

    public static float EffectBlockSpawnChance
    {
        get { return configurationData.EffectBlockSpawnChance; }
    }

    public static float FreezerDuration
    {
        get { return configurationData.FreezerDuration; }
    }

    public static float SpeedupDuration
    {
        get { return configurationData.SpeedupDuration; }
    }

    public static int SpeedupMultiplier
    {
        get { return configurationData.SpeedupMultiplier; }
    }

    public static float BlockSpawnChance
    {
        get { return configurationData.BlockSpawnChance; }
    }

    public static int BlockRowsToBuild
    {
        get { return configurationData.BlockRowsToBuild; }
    }


    private static ConfigurationData configurationData;


    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize(Difficulty diff)
    {
        configurationData = new ConfigurationData(diff);
    }
}
