using System;
using System.Collections.Generic;
using UnityEngine;

public class JSONParser : MonoBehaviour
{
    public static JSONParser Instance { get; private set; }
    public TextAsset jsonFile;

    public List<NPC> npcList = new List<NPC>();


    [System.Serializable]
    public class NPCs
    {
        public NPC[] npcs;
    }

    public class NPCParseException : Exception
    {
        public NPCParseException(string message) : base(message) { }
    }


    void Awake()    // Parses the JSON file and populates the horseList with Horse objects
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

        
        NPCs npcsInJson = JsonUtility.FromJson<NPCs>(jsonFile.text);
        if (npcsInJson == null || npcsInJson.npcs == null)
        {
            throw new NPCParseException($"Could not parse JSON: {jsonFile}");
        }

        foreach (NPC npc in npcsInJson.npcs)
        {
            npcList.Add(npc);
        }
    }

    public int SearchForNPC(string NPCToFind) // Searching for NPC (currently unused)
    {
        NPC result = npcList.Find(x => x.name == NPCToFind);
        return npcList.IndexOf(result);
    }
}