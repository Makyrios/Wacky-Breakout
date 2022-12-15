using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void HandleOnPlayButtonEvent()
    {
        MenuManager.GoToMenu(MenuName.Difficulty);
    }

    public void HandleOnHighScoreButtonEvent()
    {
        MenuManager.GoToMenu(MenuName.HighScore);
    }

    public void HandleOnQuitButtonEvent()
    {
        Application.Quit();
    }

}
