using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskInteraction : MonoBehaviour
{
    public GameObject player;
    private float distance;

    public string objectName;

    public Text buttonText;
    public float buttonNumber;

    // Task-Specific Variables
    private Animator anim;
    public string animName;
    public GameObject spawnObj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void taskCheck()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 4f)
        {
            if(objectName == "Button")
            {
                ButtonPress();
            } else if(objectName == "Plants")
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

    void ButtonPress()
    {
        anim.Play(animName);
    }

    void WaterPlants()
    {
        //anim.Play(animName);
    }

    void FixPrinter()
    {
        //anim.Play(animName);
        
    }

    void FilePapers()
    {
        //anim.Play(animName);
    }

    void GetCoffee()
    {
        //anim.Play(animName);
        GameObject newCoffee = Instantiate(spawnObj, new Vector3(0,0,0), Quaternion.Euler(new Vector3(0,0,0)));
    }

    void GetMail()
    {
        //anim.Play(animName);
        GameObject newMail = Instantiate(spawnObj, new Vector3(0,0,0), Quaternion.Euler(new Vector3(0,0,0)));
    }
}
