using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields

    public static ConfigurationData configurationData;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return DifficultyUtils.BallImpulseForce; }
    }

    public static float BallLifeTime
    {
        get { return configurationData.BallLifeSeconds; }
    }

    public static float MinSpawnTime
    {
        get { return configurationData.MinSpawnSeconds; }
    }

    public static float MaxSpawnTime
    {
        get { return configurationData.MaxSpawnSeconds; }
    }

    public static int BallsPerGame
    {
        get { return configurationData.BallsPerGame; }
    }

    public static int StandardBlockPoints
    {
        get { return configurationData.StandardBlockPoints; }
    }

    public static int BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }

    public static int EffectBlockPoints
    {
        get { return configurationData.EffectBlockPoints; }
    }

    public static float StandardBlockProb
    {
        get { return configurationData.StandardBlockProb; }
    }

    public static float BonusBlockProb
    {
        get { return configurationData.BonusBlockProb; }
    }

    public static float FreezerBlockProb
    {
        get { return configurationData.FreezerBlockProb; }
    }

    public static float SpeedupBlockProb
    {
        get { return configurationData.SpeedupBlockProb; }
    }

    public static float FreezerEffectDuration
    {
        get { return configurationData.FreezerEffectDuration; }
    }

    public static float SpeedupEffectDuration
    {
        get { return configurationData.SpeedupEffectDuration; }
    }

    public static float SpeedupFactor
    {
        get { return configurationData.SpeedupFactor; }
    }

    public static float EasyBallImpulseForce
    {
        get { return configurationData.EasyImpulseForce; }
    }

    public static float MediumBallImpulseForce
    {
        get { return configurationData.MediumImpulseForce; }
    }

    public static float HardBallImpulseForce
    {
        get { return configurationData.HardImpulseForce; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
