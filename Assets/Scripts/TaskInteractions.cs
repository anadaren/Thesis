using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskInteractions : MonoBehaviour
{
    public CountdownTimer gameStage;

    public Slider objectSlider;
    public string objectName;


    public bool canInteract = false;

    public AudioSource taskSound;

    public AudioClip siren;

    public AudioClip ding;

    public Interaction interaction;

    private bool isSirenPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        taskSound = GetComponent<AudioSource>();
        objectSlider.maxValue = 180;
        objectSlider.value = objectSlider.maxValue;
    }

    void Update()
    {
        HandleCountdown();

        if(canInteract)
        {
            if(Input.GetKeyDown(KeyCode.Space))
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
    }

    void HandleCountdown()
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
        taskSound.clip = siren;
        taskSound.loop = true;
        taskSound.Play();
        isSirenPlaying = true;
    }

    void StopSiren()
    {
        taskSound.Stop();
        isSirenPlaying = false;
    }

    

    public void CheckMessages()
    {
        ResetSlider();
    }

    void ButtonPress()
    {
        ResetSlider();
    }

    void WaterPlants()
    {
        ResetSlider();
    }

    void FixPrinter()
    {
        ResetSlider();
    }

    void FilePapers()
    {
        ResetSlider();
    }

    void GetCoffee()
    {
        //anim.Play(animName);
        //GameObject newCoffee = Instantiate(spawnObj, new Vector3(0,0,0), Quaternion.Euler(new Vector3(0,0,0)));
        ResetSlider();
    }

    void GetMail()
    {
        //anim.Play(animName);
        //GameObject newMail = Instantiate(spawnObj, new Vector3(0,0,0), Quaternion.Euler(new Vector3(0,0,0)));
        ResetSlider();
    }

    void ResetSlider()
    {
        objectSlider.value = objectSlider.maxValue;
        taskSound.clip = ding;
        taskSound.loop = false;
        taskSound.Play();
    }
}
