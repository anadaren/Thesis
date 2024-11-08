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

    /*public List<NPC> npcList;

    void Awake()
    {
        public NPC[] npcs;

        NPC npcsInJson = JsonUtility.FromJson<NPC>(jsonFile.text);
        if (npcsInJson == null || npcsInJson.npcs == null)
        {
            throw new NPCParseException($"Could not parse npcs JSON: {jsonFile}");
        }

        foreach (NPC npc in npcsInJson.npcs)
        {
            npcList.Add(npc);
        }
    }*/
}
