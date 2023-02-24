using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskInteraction : MonoBehaviour
{
    public GameObject player;
    private float distance;

    public CountdownTimer gameStage;

    public Slider objectSlider;
    public string objectName;

    public AudioSource siren;


    //public float timeCounter;



    /*public float gameTime;
    
    private bool stopTimer;



    public Text buttonText;
    public float buttonNumber;

    // Task-Specific Variables
    private Animator anim;
    public string animName;
    public GameObject spawnObj;*/


    // Start is called before the first frame update
    void Start()
    {
        objectSlider.maxValue = 90;
        objectSlider.value = 90;
        //timeCounter = 60;
            //stopTimer = false;
        //objectSlider.maxValue = gameTime;
        //objectSlider.value = gameTime;
    }

    void Update()
    {
        // max amount of time on slider goes down as time goes down
        if (CountdownTimer.currentTime >= 450)
        {
            objectSlider.maxValue = 90;
        }
        else if (CountdownTimer.currentTime >= 300)
        {
            objectSlider.maxValue = 60;
        }
        else if (CountdownTimer.currentTime >= 150)
        {
            objectSlider.maxValue = 30;
        }
        else if (CountdownTimer.currentTime == 0)
        {
            // sirens stop
            siren.Stop();
        }

        objectSlider.value -= Time.deltaTime;


        if (objectSlider.value < 10 && !siren.isPlaying)
        {
            siren.Play();
        } else if (objectSlider.value > 10 && siren.isPlaying)
        {
            siren.Stop();
        }

        //taskCheck();

        /*float time = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        if(time <= 0)
        {
            stopTimer = true;
        
        }*/
    }

    // Update is called once per frame
    public void taskCheck()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 4f)
        {
            if (objectName == "Messages")
            {
                CheckMessages();
            } else if(objectName == "Button")
            {
                ButtonPress();
            } else if(objectName == "Plant")
            {
                WaterPlants();
            } else if(objectName == "Printer")
            {
                FixPrinter();
            } else if(objectName == "Files")
            {
                FilePapers();
            } else if(objectName == "Coffee")
            {
                GetCoffee();
            } else if(objectName == "Mailbox")
            {
                GetMail();
            }
        }
    }

    public void CheckMessages()
    {
        //if(objectSlider.value <= 0)
        //{
        //    siren.Play();
        //}
        objectSlider.value = objectSlider.maxValue;
    }

    void ButtonPress()
    {
        //anim.Play(animName);
        objectSlider.value = objectSlider.maxValue;
    }

    void WaterPlants()
    {
        //anim.Play(animName);

        //waterMeter++;
        //if (waterMeter <= 0)
        // {

        // }
        objectSlider.value = objectSlider.maxValue;
    }

    void FixPrinter()
    {
        //anim.Play(animName);
        objectSlider.value = objectSlider.maxValue;
    }

    void FilePapers()
    {
        //anim.Play(animName);
        objectSlider.value = objectSlider.maxValue;
    }

    void GetCoffee()
    {
        //anim.Play(animName);
        //GameObject newCoffee = Instantiate(spawnObj, new Vector3(0,0,0), Quaternion.Euler(new Vector3(0,0,0)));
        objectSlider.value = objectSlider.maxValue;
    }

    void GetMail()
    {
        //anim.Play(animName);
        //GameObject newMail = Instantiate(spawnObj, new Vector3(0,0,0), Quaternion.Euler(new Vector3(0,0,0)));
        objectSlider.value = objectSlider.maxValue;
    }
}
