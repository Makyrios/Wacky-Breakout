using UnityEngine;
using UnityEngine.Events;

public class DifficultyMenu : MonoBehaviour
{
    private GameStartedEvent gameStartedEvent;
    private void Awake()
    {
        gameStartedEvent = new GameStartedEvent();
    }

    private void Start()
    {
        EventManager.AddGameStartedInvoker(this);
    }

    public void AddGameStartedListener(UnityAction<Difficulty> script)
    {
        gameStartedEvent.AddListener(script);
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
