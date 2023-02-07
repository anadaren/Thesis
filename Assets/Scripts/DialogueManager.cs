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

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

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
        //play talking sound
        talking.Play();
        //play talking animation
        anim.Play("Talking");
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogueSet1[curResponseTracker];
    }

    void ContinueConversation()
    {
        curResponseTracker++;

        if(curResponseTracker < npc.dialogueSet1.Length)
        {
            npcDialogueBox.text = npc.dialogueSet1[curResponseTracker];
        } else
        {
            EndConversation();
        }
            
    }

    void EndConversation()
    {
        isTalking = false;
        //STOP talking sound
        talking.Stop();
        //STOP talking animation
        anim.Play("Idle");
        dialogueUI.SetActive(false);
    }

}
