using UnityEngine.SceneManagement;

public static class DifficultyUtils
{

    static void HandleGameStartedEvent(Difficulty diff)
    {
        ConfigurationUtils.Initialize(diff);
        SceneManager.LoadScene("Gameplay");
    }

    public static void Initialize()
    {
        EventManager.AddGameStartedListener(HandleGameStartedEvent);
    }

}
