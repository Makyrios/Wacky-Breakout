using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool canSpawn;

    private void Start()
    {
        isGameOver = false;
        canSpawn = true;
        EventManager.AddLastBallLostListener(EndGame);
        EventManager.AddBlockDestroyedListener(WinEndGame);
        EventManager.AddNoRemainingBallsListener(DisableBallSpawn);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        Time.timeScale = 0;
        MenuManager.GoToMenu(MenuName.GameOver);
    }

    public void WinEndGame(int i)
    {
        if (GameObject.FindGameObjectsWithTag("Block").Length < 2)
        {
            EndGame();
        }
    }

    private void DisableBallSpawn()
    {
        canSpawn = false;
    }

}
