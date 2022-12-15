using System;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields
    const string ConfigurationDataEasyFileName = "easy.csv";
    const string ConfigurationDataMediumFileName = "medium.csv";
    const string ConfigurationDataHardFileName = "hard.csv";

    // configuration data
    float paddleMoveUnitsPerSecond = 5;
    float ballMaxSpeed = 5;
    float ballImpulseForce = 250;
    float topBlockSpawnLocation = 4;
    float bottomBlockSpawnLocation = 2;
    float ballLifeSeconds = 10;
    float minSpawnSeconds = 5;
    float maxSpawnSeconds = 10;
    int ballsPerGame = 5;
    int standardBlockWorth = 1;
    int longBlockWorth = 2;
    int bonusBlockWorth = 3;
    int effectBlockWorth = 4;
    float standardBlockSpawnChance = 0.7f;
    float longBlockSpawnChance = 0.2f;
    float bonusBlockSpawnChance = 0.05f;
    float effectBlockSpawnChance = 0.05f;
    float freezerDuration = 2;
    float speedupDuration = 5;
    int speedupMultiplier = 2;
    float blockSpawnChance = 0.75f;
    int blockRowsToBuild = 3;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    public float BallMaxSpeed
    {
        get { return ballMaxSpeed; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }
    }

    /// <summary>
    /// Gets Y coordinate of top block spawn location
    /// </summary>
    public float TopBlockSpawnLocation
    {
        get { return topBlockSpawnLocation; }
    }

    /// <summary>
    /// Gets Y coordinate of bottom block spawn location
    /// </summary>
    public float BottomBlockSpawnLocation
    {
        get { return bottomBlockSpawnLocation; }
    }

    /// <summary>
    /// Gets the number of seconds the ball lives
    /// </summary>
    /// <value>ball life seconds</value>
    public float BallLifeSeconds
    {
        get { return ballLifeSeconds; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// </summary>
    /// <value>minimum spawn seconds</value>
    public float MinSpawnSeconds
    {
        get { return minSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// </summary>
    /// <value>maximum spawn seconds</value>
    public float MaxSpawnSeconds
    {
        get { return maxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the number of balls
    /// </summary>
    public int BallsPerGame
    {
        get { return ballsPerGame; }
    }

    public int StandardBlockWorth
    {
        get { return standardBlockWorth; }
    }

    public int LongBlockWorth
    {
        get { return longBlockWorth; }
    }

    public int BonusBlockWorth
    {
        get { return bonusBlockWorth; }
    }

    public int EffectBlockWorth
    {
        get { return effectBlockWorth; }
    }

    public float StandardBlockSpawnChance
    {
        get { return standardBlockSpawnChance; }
    }

    public float LongBlockSpawnChance
    {
        get { return longBlockSpawnChance; }
    }

    public float BonusBlockSpawnChance
    {
        get { return bonusBlockSpawnChance; }
    }

    public float EffectBlockSpawnChance
    {
        get { return effectBlockSpawnChance; }
    }

    public float FreezerDuration
    {
        get { return freezerDuration; }
    }

    public float SpeedupDuration
    {
        get { return speedupDuration; }
    }

    public int SpeedupMultiplier
    {
        get { return speedupMultiplier; }
    }

    public float BlockSpawnChance
    {
        get { return blockSpawnChance; }
    }

    public int BlockRowsToBuild
    {
        get { return blockRowsToBuild; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData(Difficulty diff)
    {
        ReadData(diff);
    }

    public void ReadData(Difficulty difficulty)
    {
        string path = Application.streamingAssetsPath + "/";
        switch (difficulty)
        {
            case Difficulty.Easy:
                path += ConfigurationDataEasyFileName;
                break;
            case Difficulty.Medium:
                path += ConfigurationDataMediumFileName;
                break;
            case Difficulty.Hard:
                path += ConfigurationDataHardFileName;
                break;
        }
        StreamReader streamReader = null;
        try
        {
            streamReader = new StreamReader(path);
            streamReader.ReadLine();
            String[] values = streamReader.ReadLine().Split(',');

            paddleMoveUnitsPerSecond = float.Parse(values[0]);
            ballMaxSpeed = float.Parse(values[1]);
            ballImpulseForce = float.Parse(values[2]);
            topBlockSpawnLocation = float.Parse(values[3]);
            bottomBlockSpawnLocation = float.Parse(values[4]);
            minSpawnSeconds = float.Parse(values[5]);
            maxSpawnSeconds = float.Parse(values[6]);
            ballsPerGame = int.Parse(values[7]);
            standardBlockWorth = int.Parse(values[8]);
            longBlockWorth = int.Parse(values[9]);
            bonusBlockWorth = int.Parse(values[10]);
            effectBlockWorth = int.Parse(values[11]);
            standardBlockSpawnChance = int.Parse(values[12]) / 100f;
            longBlockSpawnChance = int.Parse(values[13]) / 100f;
            bonusBlockSpawnChance = int.Parse(values[14]) / 100f;
            effectBlockSpawnChance = int.Parse(values[15]) / 100f;
            freezerDuration = float.Parse(values[16]);
            speedupDuration = float.Parse(values[17]);
            speedupMultiplier = int.Parse(values[18]);
            blockSpawnChance = float.Parse(values[19]) / 100f;
            blockRowsToBuild = int.Parse(values[20]);
        }
        catch (Exception e)
        {
            Debug.Log("Could not open file " + e);
        }
        finally
        {
            if (streamReader != null)
            {
                streamReader.Close();
            }
        }
    }

    #endregion
}
