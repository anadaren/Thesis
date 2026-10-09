using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance { get; private set; }

    // Warning text notification
    public GameObject warning;
    public Animator warningAnim;
    public Text warningText;
    public int lateTasks = 0;

    public AudioClip siren;

    public AudioClip ding;

    private Task currentTask;

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
        warning.SetActive(false);
    }

    void Update()
    {
        CheckWarning();
    }
    
    void CheckWarning()
    {
        if(lateTasks > 0)
        {
            if(warning.active) warningText.text = "WARNING: Behind on (" + lateTasks + ") task(s).";
            else warning.SetActive(true);
        }
        else
        {
            if(warning.active) StartCoroutine(CancelWarning());
        }
    }

    IEnumerator CancelWarning()
    {
        warningAnim.SetTrigger("Cancel");
        yield return new WaitForSeconds(1f);
        warning.SetActive(false);
    }

    public void AssignCurrentTask(Task task)
    {
        currentTask = task;
    }

    public void HandleInteraction(string objectName)
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

    public void CheckMessages()
    {
        currentTask.ResetSlider();
    }

    void ButtonPress()
    {
        currentTask.ResetSlider();
    }

    void WaterPlants()
    {
        currentTask.ResetSlider();
    }

    void FixPrinter()
    {
        currentTask.ResetSlider();
    }

    void FilePapers()
    {
        currentTask.ResetSlider();
    }

    void GetCoffee()
    {
        //anim.Play(animName);
        //GameObject newCoffee = Instantiate(spawnObj, new Vector3(0,0,0), Quaternion.Euler(new Vector3(0,0,0)));
        currentTask.ResetSlider();
    }

    void GetMail()
    {
        //anim.Play(animName);
        //GameObject newMail = Instantiate(spawnObj, new Vector3(0,0,0), Quaternion.Euler(new Vector3(0,0,0)));
        currentTask.ResetSlider();
    }

    


}