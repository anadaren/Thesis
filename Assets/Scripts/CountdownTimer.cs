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
        // Checks if ending has been reached   
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            checkStage();
        }
        else
        {
            currentTime = 0;
            endReached = true;
        }

        if (currentTime <= 0 && endReached == false)
        {

            //play ending cutscene
            events.endingScene();
            endReached = true;
        }
        
        // Displays Time on big timer
        DisplayTime(currentTime);



    }

    void checkStage()
    {
        //Checks which of the four stages the game is in
        //Triggers events at different times
        if (currentTime <= 450 && currentTime > 300)
        {
            gameStage = 2;

            if (twoReached == false)
            {
                events.eventTwo();
                twoReached = true;
            }
        }
        else if (currentTime <= 300 && currentTime > 150)
        {
            gameStage = 3;
            if (threeReached == false)
            {
                events.eventThree();
                threeReached = true;
            }
        }
        else if (currentTime <= 150)
        {
            gameStage = 4;
            if (fourReached == false)
            {
                events.eventFour();
                fourReached = true;
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

    void eventFunction(float time)
    {

    }

}
