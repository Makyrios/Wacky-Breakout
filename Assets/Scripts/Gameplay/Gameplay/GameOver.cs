using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI score;
    HUD hud;

    private void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        score.text = "Score: " + hud.Score;
        hud.gameObject.SetActive(false);

        PlayerPrefs.SetInt("High Score", hud.Score);
    }

    public void HandleOnQuitEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.MainMenu);
    }
}
