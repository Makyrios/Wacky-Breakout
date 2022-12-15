using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;

    // Timer for respawn every from min to max seconds
    Timer newBallTimer;
    // Timer to spawn new ball if spawn collision is busy
    Timer noCollisionSpawnTimer;

    GameObject currentBall;

    float ballRadius;


    // Start is called before the first frame update
    void Start()
    {
        currentBall = Instantiate(ballPrefab);

        // Get radius of ball
        ballRadius = ballPrefab.GetComponent<CircleCollider2D>().radius;

        // Timers to spawn new ball
        newBallTimer = gameObject.AddComponent<Timer>();
        newBallTimer.Duration = Random.Range(ConfigurationUtils.MinBallSpawnTime, ConfigurationUtils.MaxBallSpawnTime);
        newBallTimer.Run();
        newBallTimer.AddTimerFinishedEventListener(SpawnBall);

        noCollisionSpawnTimer = gameObject.AddComponent<Timer>();
        noCollisionSpawnTimer.Duration = 1;
        noCollisionSpawnTimer.Run();
        noCollisionSpawnTimer.AddTimerFinishedEventListener(SpawnBall);

        // Event to spawn new ball after ball death
        EventManager.AddBallDiedListener(RespawnBall);

        EventManager.AddNoRemainingBallsListener(DisableSpawn);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnBall()
    {
        if (GameplayManager.canSpawn)
        {
            int maxTries = 20;
            int i = 0;
            do
            {
                currentBall = NoCollisionSpawnBall();
                i++;
            } while (i <= maxTries && currentBall == null);
        }
    }

    private GameObject NoCollisionSpawnBall()
    {
        if (Physics2D.OverlapArea(new Vector2(Vector2.zero.x - ballRadius, Vector2.zero.y + ballRadius),
            new Vector2(Vector2.zero.x + ballRadius, Vector2.zero.y - ballRadius)) == null)
        {
            return Instantiate(ballPrefab);
        }
        return null;
    }


    private void SpawnBall()
    {
        if (GameplayManager.canSpawn)
        {
            currentBall = NoCollisionSpawnBall();
            newBallTimer.Run();
        }
    }

    private void DisableSpawn()
    {
        newBallTimer.Stop();
        noCollisionSpawnTimer.Stop();
    }

}
