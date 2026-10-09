using System.Collections;
using Microsoft.VisualBasic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    public float playerSensitivity = 2;
    public float playerSpeed = 5;

    public Interaction interaction;

    [Header("Dialogue variables")]
    public GameObject dialogueUI;
    public Text npcName;
    public Text npcDialogueBox;
    int curResponseTracker = 0;
    static bool isTalking = false;

    private EventManager dialogueSet;

    [Header("Current NPC variables")]
    private DialogueObject currentNpc;

    public string baseAnimText = "Idle";
    public string talkAnimText = "Talking";
    private Animator anim;
    private AudioSource talking;


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

    void Start()
    {
        // EventManager
        dialogueSet = EventManager.Instance;
        // Sets presence of the UI textbox to false
        dialogueUI.SetActive(false);
        interaction = GetComponent<Interaction>();
    }

    public void AssignCurrentText(DialogueObject npc)
    {
        currentNpc = npc;
        anim = npc.anim;
        talking = npc.talking;
    }



    public void DialogueCheck()
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

            interaction.interactText.GetComponent<Text>().text = "Press Space to Interact.";
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
        npcName.text = currentNpc.npc.name;

        // Dialogue set changes as time goes on
        if (EventManager.currentDialogueSet == 1) 
        {
            npcDialogueBox.text = currentNpc.npc.dialogueSet1[curResponseTracker];
        } else if (EventManager.currentDialogueSet == 2)
        {
            npcDialogueBox.text = currentNpc.npc.dialogueSet2[curResponseTracker];
        } else if (EventManager.currentDialogueSet == 3)
        {
            npcDialogueBox.text = currentNpc.npc.dialogueSet3[curResponseTracker];
        } else if (EventManager.currentDialogueSet == 4)
        {
            npcDialogueBox.text = currentNpc.npc.dialogueSet4[curResponseTracker];
        }
    }

    void ContinueConversation()
    {
        curResponseTracker++;
        npcName.text = currentNpc.npc.name;

        if (EventManager.currentDialogueSet == 1) // Phase 1
        {
            if (curResponseTracker < currentNpc.npc.dialogueSet1.Length)
            {
                npcDialogueBox.text = currentNpc.npc.dialogueSet1[curResponseTracker];
            }
            else
            {
                EndConversation();
            }
        } else if (EventManager.currentDialogueSet == 2) // Phase 2
        {
            if (curResponseTracker < currentNpc.npc.dialogueSet2.Length)
            {
                npcDialogueBox.text =currentNpc.npc.dialogueSet2[curResponseTracker];
            }
            else
            {
                EndConversation();
            }
        } else if (EventManager.currentDialogueSet == 3) // Phase 3
        {
            if (curResponseTracker < currentNpc.npc.dialogueSet3.Length)
            {
                npcDialogueBox.text = currentNpc.npc.dialogueSet3[curResponseTracker];
            }
            else
            {
                EndConversation();
            }
        } else if (EventManager.currentDialogueSet == 4) // Phase 4
        {
            if (curResponseTracker < currentNpc.npc.dialogueSet4.Length)
            {
                npcDialogueBox.text = currentNpc.npc.dialogueSet4[curResponseTracker];
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