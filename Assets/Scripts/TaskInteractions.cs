using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskInteractions : MonoBehaviour
{
    public Slider objectSlider;
    public string objectName;

    public bool canInteract = false;

    public AudioSource taskSound;

    public AudioClip siren;

    public AudioClip ding;

    public Interaction interaction;

    private bool isSirenPlaying = false;

    // Warning text notification
    public GameObject warning;
    public Animator warningAnim;
    public Text warningText;
    private int lateTasks = 0;

    // Start is called before the first frame update
    void Start()
    {
        taskSound = GetComponent<AudioSource>();
        objectSlider.maxValue = 180;
        objectSlider.value = objectSlider.maxValue;
        warning.SetActive(false);
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
        int currentStage = CountdownTimer.Instance.gameStage;

            // max amount of time on slider goes down as time goes down
            if(!CountdownTimer.Instance.endReached)
            {
                if (currentStage == 1)
                {
                    objectSlider.maxValue = 180;
                }
                else if (currentStage == 2)
                {
                    objectSlider.maxValue = 150;
                }
                else if (currentStage == 3)
                {
                    objectSlider.maxValue = 120;
                }
            }
            else
            {
                StopSiren();
            }

            // Displays slider value
            objectSlider.value -= Time.deltaTime;

            // If time is running out play siren
            if (objectSlider.value < 5 && !isSirenPlaying)
            {
                lateTasks++;
                PlaySiren();
            }
            else if (objectSlider.value > 5 && isSirenPlaying)
            {
                lateTasks--;
                StopSiren();
            }
            
            // Warning text
            if(lateTasks > 0)
            {
                warningText.text = "WARNING: Behind on (" + lateTasks + ") task(s).";
                if(!warning.active) warning.SetActive(true);
                
            } else if(lateTasks == 0 && warning.active) { StartCoroutine(WarningNotif()); }
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

    IEnumerator WarningNotif()
    {
        warningAnim.SetTrigger("Cancel");
        yield return new WaitForSeconds(1f);
        warning.SetActive(false);
    }
}
