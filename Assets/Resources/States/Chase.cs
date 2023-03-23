using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/States/Attack")]
public class Chase : State
{
    NPC npc;
    
    public override bool ExitState(NPC npc)
    {
        return true;
    }

    public override void ExecuteState(NPC npc)
    {
        
    }

    public override bool CheckRules(NPC npc)
    {
        return false;
    }
}
