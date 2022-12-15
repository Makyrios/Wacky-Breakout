using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    HUD hud;

    private void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }

    public void HandleOnResumeEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void HandleOnQuitEvent()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("High Score", hud.Score);
        MenuManager.GoToMenu(MenuName.MainMenu);
        Destroy(gameObject);
    }
}
