using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour 
{
    /// <summary>
    /// Awake is called before Start
    /// </summary>
	void Awake()
    {
        // initialize screen utils
        ScreenUtils.Initialize();

        // initialize configuration utils
        ConfigurationUtils.Initialize();

        // initialize difficulty utils
        DifficultyUtils.Initialize();
    }
}
