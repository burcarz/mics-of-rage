using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    [SerializeField]
    private List<State> transitions;

    // public virtual EnemyState StateType { get; }

    public List<State> Transitions => this.transitions;

    public abstract bool ExitState(NPC npc);

    public abstract void ExecuteState(NPC npc);

    public abstract bool CheckRules(NPC npc);

}
