using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class DifficultyUtils
{
    static Difficulty difficulty;

    public static float BallImpulseForce
    {
        get
        {
            switch(difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyBallImpulseForce;

                case Difficulty.Medium:
                    return ConfigurationUtils.MediumBallImpulseForce;

                case Difficulty.Hard:
                    return ConfigurationUtils.HardBallImpulseForce;

                default:
                    return ConfigurationUtils.EasyBallImpulseForce;
            }
        }
    }

    public static void Initialize()
    {
        EventManager.AddGameStartedListener(HandleGameStartedEvent);
    }

    public static void HandleGameStartedEvent(Difficulty gameDifficulty)
    {
        difficulty = gameDifficulty;
        SceneManager.LoadScene("Scene0");
    }
}
