using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event Manager
/// </summary>
public static class EventManager
{
    static List<Ball> ballDiedInvokers = new List<Ball>();
    static List<UnityAction> ballDiedListeners = new List<UnityAction>();

    static List<Ball> ballLostInvokers = new List<Ball>();
    static List<UnityAction> ballLostListeners = new List<UnityAction>();

    static List<Block> pointsAddedInvokers = new List<Block>();
    static List<UnityAction<int>> pointsAddedListeners = new List<UnityAction<int>>();

    static List<EffectBlock> freezerEffectActivatedInvokers = new List<EffectBlock>();
    static List<UnityAction<float>> freezerEffectActivatedListeners = new List<UnityAction<float>>();

    static List<EffectBlock> speedupEffectActivatedInvokers = new List<EffectBlock>();
    static List<UnityAction<float,float>> speedupEffectActivatedListeners = new List<UnityAction<float,float>>();

    static List<DifficultyMenu> gameStartedInvokers = new List<DifficultyMenu>();
    static List<UnityAction<Difficulty>> gameStartedListeners = new List<UnityAction<Difficulty>>();

    static List<HUD> lastBallLostInvokers = new List<HUD>();
    static List<UnityAction> lastBallLostListeners = new List<UnityAction>();

    static List<Block> blockDestroyedInvokers = new List<Block>();
    static List<UnityAction> blockDestroyedListeners = new List<UnityAction>();

    public static void AddBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Add(invoker);

        foreach(UnityAction listener in ballDiedListeners)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    public static void AddBallDiedListener(UnityAction handler)
    {
        ballDiedListeners.Add(handler);

        foreach(Ball invoker in ballDiedInvokers)
        {
            invoker.AddBallDiedListener(handler);
        }
    }

    public static void RemoveBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Remove(invoker);
    }

    public static void AddBallLostInvoker(Ball invoker)
    {
        ballLostInvokers.Add(invoker);

        foreach(UnityAction listener in ballLostListeners)
        {
            invoker.AddBallLostListener(listener);
        }
    }

    public static void AddBallLostListener(UnityAction handler)
    {
        ballLostListeners.Add(handler);

        foreach(Ball invoker in ballLostInvokers)
        {
            invoker.AddBallLostListener(handler);
        }
    }

    public static void RemoveBallLostInvoker(Ball invoker)
    {
        ballLostInvokers.Remove(invoker);
    }

    public static void AddPointsAddedInvoker(Block invoker)
    {
        pointsAddedInvokers.Add(invoker);

        foreach(UnityAction<int> listener in pointsAddedListeners)
        {
            invoker.AddPointsAddedEventListener(listener);
        }
    }

    public static void AddPointsAddedListener(UnityAction<int> handler)
    {
        pointsAddedListeners.Add(handler);

        foreach(Block invoker in pointsAddedInvokers)
        {
            invoker.AddPointsAddedEventListener(handler);
        }
    }

    public static void RemovePointsAddedInvoker(Block invoker)
    {
        pointsAddedInvokers.Remove(invoker);
    }

    public static void AddFreezerEffectActivatedInvoker(EffectBlock invoker)
    {
        freezerEffectActivatedInvokers.Add(invoker);

        foreach(UnityAction<float> listener in freezerEffectActivatedListeners)
        {
            invoker.FreezerEffectActivatedEventListener(listener);
        }
    }

    public static void AddFreezerEffectActivatedListener(UnityAction<float> handler)
    {
        freezerEffectActivatedListeners.Add(handler);

        foreach(EffectBlock invoker in freezerEffectActivatedInvokers)
        {
            invoker.FreezerEffectActivatedEventListener(handler);
        }
    }

    public static void RemoveFreezerEffectActivatedInvoker(EffectBlock invoker)
    {
        freezerEffectActivatedInvokers.Remove(invoker);
    }

    public static void AddSpeedupEffectActivatedInvoker(EffectBlock invoker)
    {
        speedupEffectActivatedInvokers.Add(invoker);

        foreach(UnityAction<float,float> listener in speedupEffectActivatedListeners)
        {
            invoker.SpeedupEffectActivatedEventListener(listener);
        }
    }

    public static void AddSpeedupEffectActivatedListener(UnityAction<float,float> handler)
    {
        speedupEffectActivatedListeners.Add(handler);

        foreach(EffectBlock invoker in speedupEffectActivatedInvokers)
        {
            invoker.SpeedupEffectActivatedEventListener(handler);
        }
    }

    public static void RemoveSpeedupEffectActivatedInvoker(EffectBlock invoker)
    {
        speedupEffectActivatedInvokers.Remove(invoker);
    }

    public static void RemoveSpeedupEffectActivatedListener(UnityAction<float, float> listener)
    {
        // remove listener from list and from all invokers
        speedupEffectActivatedListeners.Remove(listener);
        foreach (EffectBlock invoker in speedupEffectActivatedInvokers)
        {
            invoker.RemoveSpeedupEffectActivatedListener(listener);
        }
    }

    public static void AddGameStartedInvoker(DifficultyMenu invoker)
    {
        gameStartedInvokers.Add(invoker);

        foreach(UnityAction<Difficulty> listener in gameStartedListeners)
        {
            invoker.AddGameStartedListener(listener);
        }
    }

    public static void AddGameStartedListener(UnityAction<Difficulty> listener)
    {
        gameStartedListeners.Add(listener);

        foreach(DifficultyMenu invoker in gameStartedInvokers)
        {
            invoker.AddGameStartedListener(listener);
        }
    }

    public static void AddLastBallLostInvoker(HUD invoker)
    {
        lastBallLostInvokers.Add(invoker);

        foreach(UnityAction listener in lastBallLostListeners)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    public static void AddLastBallLostListener(UnityAction listener)
    {
        lastBallLostListeners.Add(listener);

        foreach(HUD invoker in lastBallLostInvokers)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    public static void AddBlockDestroyedInvoker(Block invoker)
    {
        blockDestroyedInvokers.Add(invoker);

        foreach(UnityAction listener in blockDestroyedListeners)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }

    public static void AddBlockDestroyedListener(UnityAction listener)
    {
        blockDestroyedListeners.Add(listener);

        foreach(Block invoker in blockDestroyedInvokers)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }

    public static void RemoveBlockDestroyedInvoker(Block invoker)
    {
        blockDestroyedInvokers.Remove(invoker);
    }
}
