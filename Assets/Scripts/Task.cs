using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public string objectName;
    public Slider objectSlider;
    
    public bool canInteract = false;

    private AudioSource taskSound;

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
                TaskManager.Instance.AssignCurrentTask(this);
                TaskManager.Instance.HandleInteraction(objectName);
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
                TaskManager.Instance.lateTasks++;
                PlaySiren();
            }
            else if (objectSlider.value > 5 && isSirenPlaying)
            {
                TaskManager.Instance.lateTasks--;
                StopSiren();
            }

    }

    public void PlaySiren()
    {
        taskSound.clip = TaskManager.Instance.siren;
        taskSound.loop = true;
        taskSound.Play();
        isSirenPlaying = true;
    }

    public void StopSiren()
    {
        taskSound.Stop();
        isSirenPlaying = false;
    }
    
    public void ResetSlider()
    {
        objectSlider.value = objectSlider.maxValue;
        taskSound.clip = TaskManager.Instance.ding;
        taskSound.loop = false;
        taskSound.Play();
    }


}
