using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float startingTime = 601f;
    public static float currentTime = 0f;

    public Text timeTxt;

    public GameManager events;

    public float gameStage = 1;
    public bool twoReached = false;
    public bool threeReached = false;
    public bool fourReached = false;
    public bool endReached = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Displays Time
        if(currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            
            //Triggers events at different times
            if(currentTime <= 450)
            {
                gameStage = 2;
                events.eventTwo();
                twoReached = true;
            } else if(currentTime <= 300)
            {
                gameStage = 3;
                events.eventThree();
                threeReached = true;
            } else if(currentTime <= 150)
            {
                gameStage = 4;
                events.eventFour();
                fourReached = true;
            }
        }
        else
        {
            currentTime = 0;
            endReached = true;
        }

        if(currentTime <= 0 && endReached == false)
        {

            //play ending cutscene
            events.endingScene();
            endReached = true;
        }

        DisplayTime(currentTime);

        
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

    void eventFunction(float time)
    {

    }

}
