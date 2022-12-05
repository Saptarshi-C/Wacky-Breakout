using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private void Start()
    {
        EventManager.AddLastBallLostListener(LastBallLostHandler);
        EventManager.AddBlockDestroyedListener(BlockDestroyedHandler);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

    void LastBallLostHandler()
    {
        EndGame();
    }

    void BlockDestroyedHandler()
    {
        if(GameObject.FindGameObjectsWithTag("Block").Length == 1)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameObject gameOverMenu = Instantiate(Resources.Load("GameOverMenu")) as GameObject;
        GameOverMenu menuScript = gameOverMenu.GetComponent<GameOverMenu>();
        HUD hudScript = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        menuScript.SetScore(hudScript.Score);
    }
}
