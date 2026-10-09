using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    static bool isTalking = false;

    public bool canInteract = false;

    int curResponseTracker = 0;

    public GameObject dialogueUI;

    private Animator anim;
    private AudioSource talking;

    public string baseAnimText = "Idle";
    public string talkAnimText = "Talking";

    public Text npcName;
    public Text npcDialogueBox;

    private EventManager dialogueSet;

    public Interaction interaction;

    public float playerSensitivity = 2;
    public float playerSpeed = 5;

    void Start()
    {
        // EventManager
        dialogueSet = EventManager.Instance;
        //Animation
        anim = GetComponent<Animator>();
        //AudioSource
        talking = GetComponent<AudioSource>();
        // Sets presence of the UI textbox to false
        dialogueUI.SetActive(false);
    }

    void Update()
    {
        if(canInteract)
        {   
            dialogueCheck();
        }
    }

    public void dialogueCheck()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Triggers dialogue on click with interaction ray
            if(isTalking == false)
            {
                StartConversation();
            } else if(isTalking == true)
            {
                ContinueConversation();
            }
        }
        
    }

    void StartConversation()
    {
        isTalking = true;
        //plays talking sound
        talking.Play();
        //plays talking animation
        anim.Play(Animator.StringToHash("Base Layer.Talking"));


        // Stores player speed/sensitivity and then locks them
        playerSpeed = interaction.controller.speed;
        playerSensitivity = interaction.controller.sensitivity;
        interaction.controller.speed = 0;
        interaction.controller.sensitivity = 0;

        //sets response to first in index
        curResponseTracker = 0;

        // Sets dialogue UI to active
        dialogueUI.SetActive(true);
        npcName.text = npc.name;

        // Dialogue set changes as time goes on
        if (EventManager.currentDialogueSet == 1) 
        {
            npcDialogueBox.text = npc.dialogueSet1[curResponseTracker];
        } else if (EventManager.currentDialogueSet == 2)
        {
            npcDialogueBox.text = npc.dialogueSet2[curResponseTracker];
        } else if (EventManager.currentDialogueSet == 3)
        {
            npcDialogueBox.text = npc.dialogueSet3[curResponseTracker];
        } else if (EventManager.currentDialogueSet == 4)
        {
            npcDialogueBox.text = npc.dialogueSet4[curResponseTracker];
        }
    }

    void ContinueConversation()
    {
        curResponseTracker++;
        npcName.text = npc.name;

        if (EventManager.currentDialogueSet == 1) // Phase 1
        {
            if (curResponseTracker < npc.dialogueSet1.Length)
            {
                npcDialogueBox.text = npc.dialogueSet1[curResponseTracker];
            }
            else
            {
                EndConversation();
            }
        } else if (EventManager.currentDialogueSet == 2) // Phase 2
        {
            if (curResponseTracker < npc.dialogueSet2.Length)
            {
                npcDialogueBox.text = npc.dialogueSet2[curResponseTracker];
            }
            else
            {
                EndConversation();
            }
        } else if (EventManager.currentDialogueSet == 3) // Phase 3
        {
            if (curResponseTracker < npc.dialogueSet3.Length)
            {
                npcDialogueBox.text = npc.dialogueSet3[curResponseTracker];
            }
            else
            {
                EndConversation();
            }
        } else if (EventManager.currentDialogueSet == 4) // Phase 4
        {
            if (curResponseTracker < npc.dialogueSet4.Length)
            {
                npcDialogueBox.text = npc.dialogueSet4[curResponseTracker];
            }
            else
            {
                EndConversation();
            }
        }
        else
        {
            EndConversation();
        }
            
    }

    void EndConversation()
    {
        StartCoroutine(EndConvo());
    }

    IEnumerator EndConvo()
    {
        isTalking = false;
        //STOPS talking sound
        talking.Stop();
        //plays talking animation
        anim.SetBool("isTalking", false);
        dialogueUI.GetComponent<Animator>().SetTrigger("EndConvo");
        yield return new WaitForSeconds(.5f);
        //STOPS talking animation
        //anim.Play(baseAnimText);
        dialogueUI.SetActive(false);
        curResponseTracker = 0;
        //Unlocks player position
        interaction.controller.speed = playerSpeed;
        interaction.controller.sensitivity = playerSensitivity;
    }

}
