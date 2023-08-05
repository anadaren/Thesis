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

    float distance;
    int curResponseTracker = 0;

    public GameObject player;

    public GameObject dialogueUI;
    public GameObject dialogueUI2;

    public Animator anim;
    public Animator anim2;
    public AudioSource talking;
    public AudioSource talking2;

    public string baseAnimText = "Idle";
    public string talkAnimText = "Talking";

    public Text npcName;
    public Text npcName2;
    public Text npcDialogueBox;
    public Text npcDialogueBox2;

    public GameManager dialogueSet;
    public GameManager dialogueSet2;

    public bool turnChecker = true;
    // True = Tom's turn to speak
    // False = Tim's turn to speak

    void Start()
    {
        // Sets presence of the UI textbox to false
        dialogueUI.SetActive(false);
        dialogueUI2.SetActive(false);
    }

    public void dialogueCheck()
    {
        // Checks distance between player and NPC
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 6f)
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
            // Closes textbox if you get too far away [FIX ME]
            dialogueUI.SetActive(false);
        }
    }


    void StartConversation()
    {
        // Tom talks first
        turnChecker = true;

        isTalking = true;
       
        //sets response to first in index
        curResponseTracker = 0;

        // Starts NPC 1 talking
        startNPC1();
       
    }

    void ContinueConversation()
    {
        // Switches who is talking
        turnChecker = !turnChecker;

        // If it's Tom's turn to talk
        if(turnChecker)
        {
            // Makes sure the other guy isn't talking
            stopNPC2();

            // Starts NPC 1 talking
            startNPC1();
            
        } // Or if it's Tim's turn to talk
        else if(!turnChecker)
        {
            // Makes sure the other guy isn't talking
            stopNPC1();

            // Starts NPC 2 talking
            startNPC2();
            curResponseTracker++;

        }
            
    }

    void startNPC1()
    {
         //plays Tom's talking sound
        talking.Play();

        //plays Tom's talking animation
        anim.Play(talkAnimText);

        // Sets Tom's dialogue UI to active
        dialogueUI.SetActive(true);
        npcName.text = npc.name;

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

    void startNPC2()
    {
         //plays Tim's talking sound
        talking2.Play();

        //plays Tim's talking animation
        anim2.Play(talkAnimText);

        // Sets Tim's dialogue UI to active
        dialogueUI2.SetActive(true);
        npcName2.text = npc2.name;

        if (GameManager.currentDialogueSet == 1)
            {
                if (curResponseTracker < npc2.dialogueSet1.Length)
                {
                    npcDialogueBox2.text = npc2.dialogueSet1[curResponseTracker];
                }
                else
                {
                    EndConversation();
                }
            } else if (GameManager.currentDialogueSet == 2)
            {
                if (curResponseTracker < npc2.dialogueSet2.Length)
                {
                    npcDialogueBox2.text = npc2.dialogueSet2[curResponseTracker];
                }
                else
                {
                    EndConversation();
                }
            } else if (GameManager.currentDialogueSet == 3)
            {
                if (curResponseTracker < npc2.dialogueSet3.Length)
                {
                    npcDialogueBox2.text = npc2.dialogueSet3[curResponseTracker];
                }
                else
                {
                    EndConversation();
                }
            } else if (GameManager.currentDialogueSet == 4)
            {
                if (curResponseTracker < npc2.dialogueSet4.Length)
                {
                    npcDialogueBox2.text = npc2.dialogueSet4[curResponseTracker];
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

    void stopNPC1()
    {
        //STOPS talking sound
        talking.Stop();
        //STOPS talking animation
        anim.Play(baseAnimText);
        dialogueUI.SetActive(false);
    }

    void stopNPC2()
    {
        //STOPS talking sound
        talking2.Stop();
        //STOPS talking animation
        anim2.Play(baseAnimText);
        dialogueUI2.SetActive(false);
    }

    void EndConversation()
    {
        // If it's Tom's turn to talk
        if(turnChecker)
        {
            stopNPC1();
        } else
        {
            stopNPC2();
        }

        isTalking = false;
        curResponseTracker = 0;
    }

}
