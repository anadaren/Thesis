using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager2 : MonoBehaviour
{
    public NPC npc;
    public NPC npc2;

    static bool isTalking = false;

    public bool canInteract = false;

    int curResponseTracker = 0;


    public GameObject dialogueUI;

    public Animator anim;
    public Animator anim2;

    public AudioSource talking;

    public string baseAnimText = "Idle";
    public string talkAnimText = "Talking";

    public Text npcName;
    public Text npcDialogueBox;

    public GameManager dialogueSet;

    public bool turnChecker = true;
    // True = Tom's turn to speak
    // False = Tim's turn to speak

    public string[] currentDialogueSet;
    public string[] currentDialogueSet2;

    public Interaction interaction;

    void Start()
    {
        // Sets presence of the UI textbox to false
        dialogueUI.SetActive(false);
        talking = GetComponent<AudioSource>();
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
        // Tom talks first
        turnChecker = true;

        isTalking = true;

        //plays Tom's talking sound
        talking.Play();

        //plays Tom's talking animation
        anim.Play(talkAnimText);

        // Locks player position
        interaction.controller.speed = 0;

        //sets response to first in index
        curResponseTracker = 0;

        // Sets Tom's dialogue UI to active
        dialogueUI.SetActive(true);
        npcName.text = npc.name;


        // Gets first set of dialogue
        GetCurrentDialogueSet();

        // Tom speaks first
        npcDialogueBox.text = currentDialogueSet[curResponseTracker];

        curResponseTracker++;
    }

    void ContinueConversation()
    {
        // Switches who is talking
        turnChecker = !turnChecker;
        // If it's Tom's turn to talk
        if(turnChecker && curResponseTracker < currentDialogueSet.Length)
        {
            if (curResponseTracker < currentDialogueSet.Length)
            {
                npcDialogueBox.text = currentDialogueSet[curResponseTracker];
            }
            else
            {
                EndConversation();
            }

            anim.Play(talkAnimText);
            anim2.Play(baseAnimText);
            npcName.text = npc.name;

        } // Or if it's Tim's turn to talk
        else if(!turnChecker && curResponseTracker < currentDialogueSet2.Length)
        {

            if (curResponseTracker < currentDialogueSet2.Length)
            {
                npcDialogueBox.text = currentDialogueSet2[curResponseTracker];
            }
            else
            {
                EndConversation();
            }

            curResponseTracker++;
            anim.Play(baseAnimText);
            anim2.Play(talkAnimText);
            npcName.text = npc2.name;
        } else
        {
            EndConversation();
            return;
        }
            
    }

    void GetCurrentDialogueSet()
    {
        // Dialogue set changes as time goes on
        if (GameManager.currentDialogueSet == 1) 
        {
            currentDialogueSet = npc.dialogueSet1;
            currentDialogueSet2 = npc2.dialogueSet1;
        } else if (GameManager.currentDialogueSet == 2)
        {
            currentDialogueSet = npc.dialogueSet2;
            currentDialogueSet2 = npc2.dialogueSet2;
        } else if (GameManager.currentDialogueSet == 3)
        {
            currentDialogueSet = npc.dialogueSet3;
            currentDialogueSet2 = npc2.dialogueSet3;
        } else if (GameManager.currentDialogueSet == 4)
        {
            currentDialogueSet = npc.dialogueSet4;
            currentDialogueSet2 = npc2.dialogueSet4;
        }
    }

    void EndConversation()
    {
        isTalking = false;
        //STOPS talking sound
        talking.Stop();
        //STOPS talking animation
        anim.Play(baseAnimText);
        anim2.Play(baseAnimText);
        dialogueUI.SetActive(false);
        curResponseTracker = 0;
        //Unlocks player position
        interaction.controller.speed = 5;
    }

}
