using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public static AIManager Instance;

    public List<NPC> activeAllies = new List<NPC>();
    public int npcAmount;

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void NPCUpdateCount(NPC npc)
    {
        activeAllies.Add(npc);
    }

    public void NPCRemoveCount(NPC npc)
    {
        activeAllies.Remove(npc);
    }
}
