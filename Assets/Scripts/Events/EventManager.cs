using System.Collections.Generic;
using UnityEngine.Events;

public static class EventManager
{
    private static List<Ball> ballDiedInvokers = new List<Ball>();
    private static List<UnityAction> ballDiedListeners = new List<UnityAction>();

    private static List<Block> blockDestroyedInvokers = new List<Block>();
    private static List<UnityAction<int>> blockDestroyedListeners = new List<UnityAction<int>>();

    private static List<Block> freezerBlockInvokers = new List<Block>();
    private static UnityAction<float> freezerPaddleListener;

    private static List<Block> speedupBlockInvokers = new List<Block>();
    private static UnityAction<float> speedupPaddleListener;

    private static DifficultyMenu GameStartedInvoker;
    private static UnityAction<Difficulty> GameStartedListener;

    private static Ball lastBallLostInvoker;
    private static UnityAction lastBallLostListener;

    private static HUD noRemainingBallsInvoker;
    private static UnityAction noRemainingBallsListener;

    public static void AddBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Add(invoker);
        foreach (UnityAction listener in ballDiedListeners)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    public static void AddBallDiedListener(UnityAction listener)
    {
        ballDiedListeners.Add(listener);
        foreach (Ball invoker in ballDiedInvokers)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    public static void RemoveBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Remove(invoker);
        foreach (UnityAction listener in ballDiedListeners)
        {
            invoker.RemoveBallDiedListener(listener);
        }
    }

    public static void RemoveBallDiedListener(UnityAction listener)
    {
        ballDiedListeners.Remove(listener);
        foreach (Ball invoker in ballDiedInvokers)
        {
            invoker.RemoveBallDiedListener(listener);
        }
    }


    public static void AddBlockDestroyedInvoker(Block invoker)
    {
        blockDestroyedInvokers.Add(invoker);
        foreach (UnityAction<int> listener in blockDestroyedListeners)
        {
            invoker.AddBlockDestroyedEventListener(listener);
        }
    }

    public static void AddBlockDestroyedListener(UnityAction<int> listener)
    {
        blockDestroyedListeners.Add(listener);
        foreach (Block invoker in blockDestroyedInvokers)
        {
            invoker.AddBlockDestroyedEventListener(listener);
        }
    }

    public static void RemoveBlockDestroyedInvoker(Block invoker)
    {
        blockDestroyedInvokers.Remove(invoker);
        foreach (UnityAction<int> listener in blockDestroyedListeners)
        {
            invoker.RemoveBlockDestroyedEventListener(listener);
        }
    }



    public static void AddFreezerBlockDestroyedInvoker(EffectBlock invoker)
    {
        freezerBlockInvokers.Add(invoker);
        if (freezerPaddleListener != null)
        {
            invoker.AddFreezerBlockEventListener(freezerPaddleListener);
        }
    }

    public static void AddFreezerBlockDestroyedListener(UnityAction<float> listener)
    {
        freezerPaddleListener = listener;
        foreach (EffectBlock invoker in freezerBlockInvokers)
        {
            invoker.AddFreezerBlockEventListener(freezerPaddleListener);
        }
    }

    public static void AddSpeedupBlockDestroyedInvoker(EffectBlock invoker)
    {
        speedupBlockInvokers.Add(invoker);
        if (speedupPaddleListener != null)
        {
            invoker.AddSpeedupBlockEventListener(speedupPaddleListener);
        }
    }

    public static void AddSpeedupBlockDestroyedListener(UnityAction<float> listener)
    {
        speedupPaddleListener = listener;
        foreach (EffectBlock invoker in speedupBlockInvokers)
        {
            invoker.AddSpeedupBlockEventListener(speedupPaddleListener);
        }
    }



    public static void AddGameStartedInvoker(DifficultyMenu invoker)
    {
        GameStartedInvoker = invoker;
        if (GameStartedListener != null)
        {
            GameStartedInvoker.AddGameStartedListener(GameStartedListener);
        }
    }

    public static void AddGameStartedListener(UnityAction<Difficulty> listener)
    {
        GameStartedListener = listener;
        if (GameStartedInvoker != null)
        {
            GameStartedInvoker.AddGameStartedListener(GameStartedListener);
        }
    }


    public static void AddLastBallLostInvoker(Ball invoker)
    {
        lastBallLostInvoker = invoker;
        if (lastBallLostListener != null)
        {
            lastBallLostInvoker.AddLastBallLostListener(lastBallLostListener);
        }
    }

    public static void AddLastBallLostListener(UnityAction listener)
    {
        lastBallLostListener = listener;
        if (lastBallLostInvoker != null)
        {
            lastBallLostInvoker.AddLastBallLostListener(lastBallLostListener);
        }
    }


    public static void AddNoRemainingBallsInvoker(HUD invoker)
    {
        noRemainingBallsInvoker = invoker;
        if (noRemainingBallsListener != null)
        {
            noRemainingBallsInvoker.AddNoRemainingBallsListener(noRemainingBallsListener);
        }
    }

    public static void AddNoRemainingBallsListener(UnityAction listener)
    {
        noRemainingBallsListener = listener;
        if (noRemainingBallsInvoker != null)
        {
            noRemainingBallsInvoker.AddNoRemainingBallsListener(noRemainingBallsListener);
        }
    }
}
