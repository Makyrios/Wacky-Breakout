using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Difficulty:
                SceneManager.LoadScene("Difficulty");
                break;
            case MenuName.HighScore:
                SceneManager.LoadScene("HighScore");
                break;
            case MenuName.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.GameOver:
                Object.Instantiate(Resources.Load("GameOver"));
                break;
        }
    }
}
