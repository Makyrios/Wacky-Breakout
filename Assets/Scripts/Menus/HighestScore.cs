using TMPro;
using UnityEngine;

public class HighestScore : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("High Score"))
        {
            score.text = $"{PlayerPrefs.GetInt("High Score")}";
        }
        else
        {
            score.text = "None";
        }
    }

    public void HandleOnQuitButton()
    {
        MenuManager.GoToMenu(MenuName.MainMenu);
    }

}
