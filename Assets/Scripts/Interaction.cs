using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject interactText;

    public FirstPersonController controller;


    void Start()
    {
        controller = GetComponent<FirstPersonController>(); // controller is altered in DialogueManager scripts
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "NPC")
        {
            col.gameObject.GetComponent<DialogueManager>().canInteract = true;
            interactText.GetComponent<Text>().text = "Press Space to Talk.";
            interactText.SetActive(true);
        } else if(col.gameObject.tag == "NPCpair")
        {
            col.gameObject.GetComponent<DialogueManager2>().canInteract = true;
            interactText.GetComponent<Text>().text = "Press Space to Talk.";
            interactText.SetActive(true);
        } else if(col.gameObject.tag == "Task")
        {
            col.gameObject.GetComponent<TaskInteractions>().canInteract = true;
            interactText.GetComponent<Text>().text = "Press Space to Interact.";
            interactText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "NPC")
        {
            col.gameObject.GetComponent<DialogueManager>().canInteract = false;
            interactText.SetActive(false);
        }  else if(col.gameObject.tag == "NPCpair")
        {
            col.gameObject.GetComponent<DialogueManager2>().canInteract = false;
            interactText.SetActive(false);
        }  else if(col.gameObject.tag == "Task")
        {
            col.gameObject.GetComponent<TaskInteractions>().canInteract = false;
            interactText.SetActive(false);
        }
    }
}
