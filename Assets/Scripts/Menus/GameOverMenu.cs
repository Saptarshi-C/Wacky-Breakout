using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    private Text gameOverMessage;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void SetScore(int score)
    {
        gameOverMessage.text = "Game Over\nScore: " + score.ToString();
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
    
}
