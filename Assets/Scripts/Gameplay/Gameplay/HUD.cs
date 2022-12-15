using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HUD : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI RemainingBallsText;
    [SerializeField]
    TextMeshProUGUI ScoreText;
    int remainingBalls;
    int score;
    string RemainingBallsPrefix;
    string ScorePrefix;

    NoRemainingBallsEvent noRemainingBallsEvent;

    public int Score
    {
        get { return score; }
    }

    private void Awake()
    {
        noRemainingBallsEvent = new NoRemainingBallsEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddBallDiedListener(RemoveBall);
        EventManager.AddBlockDestroyedListener(UpdateScore);
        EventManager.AddNoRemainingBallsInvoker(this);


        RemainingBallsPrefix = "Balls left: ";
        ScorePrefix = "Score: ";
        remainingBalls = ConfigurationUtils.BallsPerGame;
        score = 0;
        RemainingBallsText.text = RemainingBallsPrefix + remainingBalls;
        ScoreText.text = ScorePrefix + score;

    }

    private void RemoveBall()
    {
        remainingBalls--;
        RemainingBallsText.text = RemainingBallsPrefix + remainingBalls;
        if (remainingBalls <= 0)
        {
            EventManager.RemoveBallDiedListener(RemoveBall);
            noRemainingBallsEvent.Invoke();
        }
    }

    public void UpdateScore(int points)
    {
        score += points;
        ScoreText.text = ScorePrefix + score;
    }

    public void AddNoRemainingBallsListener(UnityAction script)
    {
        noRemainingBallsEvent.AddListener(script);
    }
}
