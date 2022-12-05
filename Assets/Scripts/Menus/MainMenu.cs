using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{    

    public void PlayGame()
    {
        MenuManager.GoToMenu(MenuName.Difficulty);
    }

    public void HelpMenu()
    {
        MenuManager.GoToMenu(MenuName.Help);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
