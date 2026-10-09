using System.Collections;
using Microsoft.VisualBasic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueObject : MonoBehaviour
{
    public NPC npc;

    

    public bool canInteract = false;

    public Animator anim;
    public AudioSource talking;


    public bool isDoor = false;

    private DialogueManager dialogueManager;

    void Start()
    {
        //Animation
        anim = GetComponent<Animator>();
        //AudioSource
        talking = GetComponent<AudioSource>();

        dialogueManager = DialogueManager.Instance;
    }

    void Update()
    {
        if(canInteract)
        {   
            dialogueManager.AssignCurrentText(this);
            dialogueManager.DialogueCheck();
        }
    }

    

}
