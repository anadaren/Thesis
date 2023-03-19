using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC file", menuName = "NPC Files Archive")]
public class NPC : ScriptableObject
{
    public string NPC_name;
    [TextArea(3, 15)]
    public string[] dialogueSet1;
    [TextArea(3, 15)]
    public string[] dialogueSet2;
    [TextArea(3, 15)]
    public string[] dialogueSet3;
    [TextArea(3, 15)]
    public string[] dialogueSet4;
    [TextArea(3, 15)]
    public string[] playerDialogue;
}
