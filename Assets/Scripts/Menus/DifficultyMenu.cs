using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DifficultyMenu : MonoBehaviour
{
    GameStartedEvent gameStartedEvent;

    private void Awake()
    {
        gameStartedEvent = new GameStartedEvent();
    }

    private void Start()
    {
        EventManager.AddGameStartedInvoker(this);
    }

    public void AddGameStartedListener(UnityAction<Difficulty> listener)
    {
        gameStartedEvent.AddListener(listener);
    }

    public void StartEasyGame()
    {
        gameStartedEvent.Invoke(Difficulty.Easy);
    }

    public void StartMediumGame()
    {
        gameStartedEvent.Invoke(Difficulty.Medium);
    }

    public void StartHardGame()
    {
        gameStartedEvent.Invoke(Difficulty.Hard);
    }
}
