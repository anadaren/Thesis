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

    private bool isSirenPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        objectSlider.maxValue = 120;
        objectSlider.value = objectSlider.maxValue;
    }

    void Update()
    {
        float currentTime = CountdownTimer.currentTime;

        // max amount of time on slider goes down as time goes down
        if(currentTime >= 0)
        {
            if (currentTime >= 450)
            {
                objectSlider.maxValue = 180;
            }
            else if (currentTime >= 300)
            {
                objectSlider.maxValue = 150;
            }
            else if (currentTime >= 150)
            {
                objectSlider.maxValue = 120;
            }
        }
        else if (currentTime == 0)
        {
            StopSiren();
        }

        // Displays slider value
        objectSlider.value -= Time.deltaTime;

        // If time is running out play siren
        if (objectSlider.value < 5 && !isSirenPlaying)
        {
            PlaySiren();
        }
        else if (objectSlider.value > 5 && isSirenPlaying)
        {
            StopSiren();
        }

    }

    void PlaySiren()
    {
        siren.Play();
        isSirenPlaying = true;
    }

    void StopSiren()
    {
        siren.Stop();
        isSirenPlaying = false;
    }

    // Update is called once per frame
    public void taskCheck()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 6f)
        {
            switch (objectName)
            {
                case "Messages":
                    CheckMessages();
                    break;
                case "Button":
                    ButtonPress();
                    break;
                case "Plant":
                    WaterPlants();
                    break;
                case "Printer":
                    FixPrinter();
                    break;
                case "Files":
                    FilePapers();
                    break;
                case "Coffee":
                    GetCoffee();
                    break;
                case "Mailbox":
                    GetMail();
                    break;
            }
        }
    }

    public void CheckMessages()
    {
        objectSlider.value = objectSlider.maxValue;
    }

    void ButtonPress()
    {
        objectSlider.value = objectSlider.maxValue;
    }

    void WaterPlants()
    {
        objectSlider.value = objectSlider.maxValue;
    }

    void FixPrinter()
    {
        objectSlider.value = objectSlider.maxValue;
    }

    void FilePapers()
    {
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
