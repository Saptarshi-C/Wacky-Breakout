using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    float paddleMoveUnitsPerSecond = 10;
    float ballImpulseForce = 10;
    float ballLifeSeconds = 10;
    float minSpawnSeconds = 5;
    float maxSpawnSeconds = 10;
    int ballsPerGame = 10;
    int standardBlockPoints = 1;
    int bonusBlockPoints = 2;
    int effectBlockPoints = 5;
    float standardBlockProb = 70;
    float bonusBlockProb = 20;
    float freezerBlockProb = 5;
    float speedupBlockProb = 5;
    float freezerEffectDuration = 2;
    float speedupEffectDuration = 2;
    float speedupFactor = 2;
    float easyImpulseForce = 8;
    float mediumImpulseForce = 13;
    float hardImpulseForce = 18;

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

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
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
    /// Gets the maximum number of balls per game
    /// </summary>
    /// <value>maximum balls per game</value>
    public int BallsPerGame
    {
        get { return ballsPerGame; }
    }

    /// <summary>
    /// Gets the points a standard block is worth
    /// </summary>
    /// <value>points for standard block</value>
    public int StandardBlockPoints
    {
        get { return standardBlockPoints; }
    }

    /// <summary>
    /// Gets the points a bonus block is worth
    /// </summary>
    /// <value>points for bonus block</value>
    public int BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    /// <summary>
    /// Gets the points a effect block is worth
    /// </summary>
    /// <value>points for effect block</value>
    public int EffectBlockPoints
    {
        get { return effectBlockPoints; }
    }

    /// <summary>
    /// Gets the probability to spawn a standard block
    /// </summary>
    /// <value>probability for standard block</value>
    public float StandardBlockProb
    {
        get { return standardBlockProb; }
    }

    /// <summary>
    /// Gets the probability to spawn a bonus block
    /// </summary>
    /// <value>probability for bonus block</value>
    public float BonusBlockProb
    {
        get { return bonusBlockProb; }
    }
    /// <summary>
    /// Gets the probability to spawn a freezer block
    /// </summary>
    /// <value>probability for freezer block</value>
    public float FreezerBlockProb
    {
        get { return freezerBlockProb; }
    }

    /// <summary>
    /// Gets the probability to spawn a speedup block
    /// </summary>
    /// <value>probability for speedup block</value>
    public float SpeedupBlockProb
    {
        get { return speedupBlockProb; }
    }

    /// <summary>
    /// Gets the duration for the freezer effect
    /// </summary>
    /// <value>duration for the freezer effect</value>
    public float FreezerEffectDuration
    {
        get { return freezerEffectDuration; }
    }

    /// <summary>
    /// Gets the duration of the speedup effect
    /// </summary>
    /// <value>duration for speedup effect</value>
    public float SpeedupEffectDuration
    {
        get { return speedupEffectDuration; }
    }

    /// <summary>
    /// Gets the speedup multiplier
    /// </summary>
    /// <value>speedup multiplier</value>
    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }

    /// <summary>
    /// Gets impulse force for easy difficulty
    /// </summary>
    public float EasyImpulseForce
    {
        get { return easyImpulseForce; }
    }

    /// <summary>
    /// Gets impulse force for medium difficulty
    /// </summary>
    public float MediumImpulseForce
    {
        get { return mediumImpulseForce; }
    }

    /// <summary>
    /// Gets impulse force for hard difficulty
    /// </summary>
    public float HardImpulseForce
    {
        get { return hardImpulseForce; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // create file handle
        StreamReader fileInput = null;

        try
        {
            // open file. combine standard streaming assets folder and file name to get full path.
            fileInput = File.OpenText(Path.Combine(Application.streamingAssetsPath,ConfigurationDataFileName));

            // read names and values from file
            string name = fileInput.ReadLine();
            string values = fileInput.ReadLine();

            // separate values and assign to fields
            ExtractValuesFromCSV(values);
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
        finally
        {
            // always close file if handle is present
            if(fileInput!=null)
            {
                fileInput.Close();
            }
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Separates CSV into individual values and assigns them to fields.
    /// </summary>
    /// <param name="CSValues">Comma Separated Values</param>
    void ExtractValuesFromCSV(string CSValues)
    {
        // Split on a comma and separate into strings
        string[] values = CSValues.Split(',');

        // parse string element as float value and assign to respective fields
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeSeconds = float.Parse(values[2]);
        minSpawnSeconds = float.Parse(values[3]);
        maxSpawnSeconds = float.Parse(values[4]);
        ballsPerGame = int.Parse(values[5]);
        standardBlockPoints = int.Parse(values[6]);
        bonusBlockPoints = int.Parse(values[7]);
        effectBlockPoints = int.Parse(values[8]);
        standardBlockProb = float.Parse(values[9]);
        bonusBlockProb = float.Parse(values[10]);
        freezerBlockProb = float.Parse(values[11]);
        speedupBlockProb = float.Parse(values[12]);
        freezerEffectDuration = float.Parse(values[13]);
        speedupEffectDuration = float.Parse(values[14]);
        speedupFactor = float.Parse(values[15]);
        easyImpulseForce = float.Parse(values[16]);
        mediumImpulseForce = float.Parse(values[17]);
        hardImpulseForce = float.Parse(values[18]);
    }
    #endregion
}
