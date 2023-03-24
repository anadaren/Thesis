using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    static bool isTalking = false;

    float distance;
    int curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;

    private Animator anim;
    private AudioSource talking;

    public string baseAnimText = "Idle";
    public string talkAnimText = "Talking";

    public Text npcName;
    public Text npcDialogueBox;
    //public Text playerResponse;

    public GameManager dialogueSet;

    void Start()
    {
        //Animation
        anim = GetComponent<Animator>();
        //AudioSource
        talking = GetComponent<AudioSource>();
        // Sets presence of the UI textbox to false
        dialogueUI.SetActive(false);
    }

    public void dialogueCheck()
    {
        // Checks distance between player and NPC
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 4f)
        {
            
            // Triggers dialogue on click with interaction ray
            if(isTalking == false)
            {
                StartConversation();
            } else if(isTalking == true)
            {
                ContinueConversation();
            }
        } else
        {
            // Closes textbox if you get too far away
            dialogueUI.SetActive(false);
        }
    }

    void StartConversation()
    {
        isTalking = true;
        //plays talking sound
        talking.Play();
        //plays talking animation
        anim.Play(talkAnimText);

        //sets response to first in index
        curResponseTracker = 0;

        // Sets dialogue UI to active
        dialogueUI.SetActive(true);
        npcName.text = npc.name;

        // Dialogue set changes as time goes on
        if (GameManager.currentDialogueSet == 1) 
        {
            npcDialogueBox.text = npc.dialogueSet1[curResponseTracker];
        } else if (GameManager.currentDialogueSet == 2)
        {
            npcDialogueBox.text = npc.dialogueSet2[curResponseTracker];
        } else if (GameManager.currentDialogueSet == 3)
        {
            npcDialogueBox.text = npc.dialogueSet3[curResponseTracker];
        } else if (GameManager.currentDialogueSet == 4)
        {
            npcDialogueBox.text = npc.dialogueSet4[curResponseTracker];
        }
    }

    void ContinueConversation()
    {
        npcName.text = npc.name;
        curResponseTracker++;

        if (GameManager.currentDialogueSet == 1)
        {
            if (curResponseTracker < npc.dialogueSet1.Length)
            {
                npcDialogueBox.text = npc.dialogueSet1[curResponseTracker];
            }
            else
            {
                EndConversation();
            }
        } else if (GameManager.currentDialogueSet == 2)
        {
            if (curResponseTracker < npc.dialogueSet2.Length)
            {
                npcDialogueBox.text = npc.dialogueSet2[curResponseTracker];
            }
            else
            {
                EndConversation();
            }
        } else if (GameManager.currentDialogueSet == 3)
        {
            if (curResponseTracker < npc.dialogueSet3.Length)
            {
                npcDialogueBox.text = npc.dialogueSet3[curResponseTracker];
            }
            else
            {
                EndConversation();
            }
        } else if (GameManager.currentDialogueSet == 4)
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
        isTalking = false;
        //STOPS talking sound
        talking.Stop();
        //STOPS talking animation
        anim.Play(baseAnimText);
        dialogueUI.SetActive(false);
        curResponseTracker = 0;
    }

}
