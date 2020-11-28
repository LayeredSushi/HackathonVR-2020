using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //TODO: set any time you want!
    private float timeRemaining = 60;
    private bool timerIsRunning = false;
    public TMP_Text timeText;

    private static Timer instance;

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
        SetBlackTextColor();

        StopTimer();
        this.timeRemaining = timeRemaining;
        timerIsRunning = true;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    public void ContinueTimer()
    {
        SetBlackTextColor();
        timerIsRunning = true;
    }

    public void SetError(string errorMessage)
    {
        StopTimer();
        SetRedTextColor();
        timeText.text = errorMessage;
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
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
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
