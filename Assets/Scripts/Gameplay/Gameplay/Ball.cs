using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb2d;
    float MaxVelocity;
    AudioSource OofSound;
    Timer startTimer;

    // Events
    BallDiedEvent ballDiedEvent;
    LastBallLostEvent lastBallLostEvent;

    private void Awake()
    {
        ballDiedEvent = new BallDiedEvent();
        lastBallLostEvent = new LastBallLostEvent();
        startTimer = gameObject.AddComponent<Timer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        MaxVelocity = ConfigurationUtils.BallMaxSpeed;
        EventManager.AddBallDiedInvoker(this);
        OofSound = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();

        startTimer.Duration = 1;
        startTimer.AddTimerFinishedEventListener(StartBall);
        startTimer.Run();

        EventManager.AddLastBallLostInvoker(this);
    }

    private void Update()
    {
        if (rb2d.velocity.magnitude > MaxVelocity)
        {
            //float breakSpeed = rb2d.velocity.magnitude - MaxVelocity;
            //Vector2 breakVector = rb2d.velocity.normalized * breakSpeed;
            //rb2d.AddForce(-breakVector);
            rb2d.velocity *= 0.99f;
        }
        else if (rb2d.velocity.magnitude < MaxVelocity)
        {
            rb2d.velocity *= 1.01f;
        }

    }

    public void SetDirection(Vector2 dir)
    {
        rb2d.velocity = dir * rb2d.velocity.magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OofSound.Play();
    }

    public void AddBallDiedListener(UnityAction script)
    {
        ballDiedEvent.AddListener(script);
    }

    public void RemoveBallDiedListener(UnityAction script)
    {
        ballDiedEvent.RemoveListener(script);
    }

    private void OnBecameInvisible()
    {
        if (GameplayManager.isGameOver)
        {
            return;
        }
        if (!GameplayManager.canSpawn && GameObject.FindGameObjectsWithTag("Ball").Length < 2)
        {
            lastBallLostEvent.Invoke();
        }
        ballDiedEvent.Invoke();
        EventManager.RemoveBallDiedInvoker(this);
        Destroy(gameObject);
    }

    public void StartBall()
    {
        float force = ConfigurationUtils.BallImpulseForce;
        rb2d.AddForce(new Vector2(0, -force), ForceMode2D.Force);
    }

    public void AddLastBallLostListener(UnityAction script)
    {
        lastBallLostEvent.AddListener(script);
    }

}
