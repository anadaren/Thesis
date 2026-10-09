using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public static CountdownTimer Instance { get; private set; }
    

    public float startingTime = 1201f;
    public float currentTime = 0f;
    private float threeQuarterTime = 900f;
    private float halfTime = 600f;
    private float quarterTime = 300f;

    public Text timeTxt;

    private EventManager events;

    public int gameStage = 1;
    public bool twoReached = false;
    public bool threeReached = false;
    public bool fourReached = false;
    public bool endReached = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        events = EventManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        // Countdown  
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            CheckStage();
        }
        else
        {
            currentTime = 0;
        }
        
        // Displays Time on big timer
        DisplayTime(currentTime);
    }

    void CheckStage()
    {
        //Checks which of the four stages the game is in
        //Triggers events at different times
        if(currentTime > threeQuarterTime) return;

        if (currentTime <= threeQuarterTime && currentTime > halfTime)
        {
            gameStage = 2;

            if (twoReached == false)
            {
                events.EventTwo();
                twoReached = true;
            }
        }
        else if (currentTime <= halfTime && currentTime > quarterTime)
        {
            gameStage = 3;
            if (threeReached == false)
            {
                events.EventThree();
                threeReached = true;
            }
        }
        else if (currentTime <= quarterTime)
        {
            gameStage = 4;
            if (fourReached == false)
            {
                events.EventFour();
                fourReached = true;
            }
        }
        else if (currentTime <= 0)
        {
            gameStage = 5;
            if(endReached == false)
            {
                //play ending cutscene
                events.EndingScene();
                endReached = true;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        
        float currentMinutes = Mathf.FloorToInt(timeToDisplay / 60);
        float currentSeconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeTxt.text = string.Format("00:{0:00}:{1:00}", currentMinutes, currentSeconds);
    }

}
