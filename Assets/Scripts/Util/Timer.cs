using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    TimerFinishedEvent timerFinishedEvent;

    float totalSeconds;
    float elapsedSeconds;
    bool started = false;
    bool running = false;
    public float Duration
    {
        set
        {
            if (value > 0)
            {
                totalSeconds = value;
            }
        }
    }

    public bool Finished
    {
        get
        {
            return (started && !running);
        }
    }

    private void Awake()
    {
        timerFinishedEvent = new TimerFinishedEvent();
    }

    public void AddTimerFinishedEventListener(UnityAction script)
    {
        timerFinishedEvent.AddListener(script);
    }


    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
            {
                running = false;
                timerFinishedEvent.Invoke();
            }
        }
    }

    /// <summary>
    /// Start timer
    /// </summary>
    public void Run()
    {
        if (!running)
        {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }

    public void Stop()
    {
        if (started)
        {
            started = false;
        }
    }




}
