using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //TODO: set any time you want!
    private float timeRemaining = 60;
    private bool timerIsRunning = false;
    public TMP_Text timeText;

    private static Timer instance;

    private void Start()
    {
        StartInstructionsSet();
    }

    public void StartInstructionsSet()
    {
        Instructions.GetInstance().GetCurrentTask();
        timeRemaining = Instructions.GetInstance().GetCurrentTaskTime();
        StartTimer(Instructions.GetInstance().GetCurrentTaskTime());
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = gameObject.GetComponent<Timer>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Timer GetInstance()
    {
        return instance;
    }

    public void StartTimer(float timeRemaining)
    {
        if (!Instructions.GetInstance().AreAllTasksCompleted())
        {
            SetBlackTextColor();

            StopTimer();
            this.timeRemaining = timeRemaining;
            timerIsRunning = true;
        }
    }

    public void StopTimer()
    {
        if (!Instructions.GetInstance().AreAllTasksCompleted())
        {
            timerIsRunning = false;
        }    
    }

    public void ContinueTimer()
    {
        if (!Instructions.GetInstance().AreAllTasksCompleted())
        {
           SetBlackTextColor();
           timerIsRunning = true;
        }
    }

    public void SetError(string errorMessage)
    {
        if (!Instructions.GetInstance().AreAllTasksCompleted())
        {
            StopTimer();
            SetRedTextColor();
            timeText.text = errorMessage;
        }
    }

    private void SetBlackTextColor()
    {
        timeText.enableAutoSizing = false;
        timeText.fontSize = 40;
        timeText.color = Color.black;
    }

    private void SetRedTextColor()
    {
        timeText.enableAutoSizing = true;
        timeText.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                 timeRemaining -= Time.deltaTime;
                 DisplayTime(timeRemaining);
            }
            else
            {
                if (Instructions.GetInstance().AreAllTasksCompleted())
                {
                    SetBlackTextColor();
                    timeText.text = "Fertig!";
                    timeRemaining = 0;
                    timerIsRunning = false; 
                }
                else
                {
                    //SetRedTextColor();
                    //timeText.text = "Schneller!";
                    //Debug.Log("Time has run out!");
                    Instructions.GetInstance().SetTaskCompleted();
                    //Move to next one
                    StartTimer(Instructions.GetInstance().GetCurrentTaskTime());
                }
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
