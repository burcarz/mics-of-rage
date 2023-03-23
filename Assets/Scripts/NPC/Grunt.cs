using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  Grunt : NPC
{

    public Text stateText;

    private Vector3 target;
    public GameObject barrier;

    private Vector3 offset;
    private float angle;

    float x;
    float y;
    float z;
    
    public enum CombatState {
        chase,
        flee,
        surround,
        stunned
    }

    public string stateString;

    CombatState state = CombatState.chase;

    new public void Start()
    {
        base.Start();
        isGrunt = true;
        barrier = GameObject.FindGameObjectWithTag("playerBarrier");
        InvokeRepeating("StateManager", 1f, 1f);
    }

    new public void Update()
    {
        base.Update();
        StateManager();
        stateText.text = state.ToString();
        stateString = state.ToString();
        // Debug.Log(state);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void Chase()
    {
        isAggro = 1;
        x = Random.Range(player.position.x - 1, player.position.x + 1);
        y = 0;
        z = Random.Range(player.position.z - 1, player.position.z + 1);
        Vector3 target = new Vector3(x, y, z);
        agent.SetDestination(target);
    }

    public void MaintainDistance()
    {
        x = Random.Range(player.position.x + 7, player.position.x + 10);
        y = 0;
        z = player.position.z;
        Vector3 target = new Vector3(x, y, z);
        agent.SetDestination(target);
        Flip(x);
    }

    public void Surround()
    {
        float radius = 1;
        float rotationSpeed = 1;
        offset.Set(
            Mathf.Cos(angle) * radius,
            0f,
            Mathf.Sin(angle) * radius
        );
        target = player.position + offset;
        angle += Time.deltaTime * rotationSpeed;
        agent.SetDestination(target);
    }

    public void Stunned()
    {
        if (stunTime > 0)
        {
            stunTime -= Time.deltaTime;
        }
        else
        {
            isStunned = false;
        }
    }

    void StateSwitch()
    {
        switch (state)
        {
            case CombatState.chase:
                    // Debug.Log("PURSUE");
                    Chase();
            break;
            case CombatState.flee:
                    // Debug.Log(" is fleeing");
                    MaintainDistance();
            break;
            case CombatState.surround:
                    // Debug.Log(" is surrounding");
                    Surround();
            break;
            case CombatState.stunned:
                    Stunned();
            break;
            default: Chase();
            break;
        }
    }

    void StateManager()
    {
        
        if (isStunned)
        {
            state = CombatState.stunned;
            StateSwitch();
        }
        else if (barrier != null || AIManager.Instance.activeAllies.Count >= 2)
        {
            state = CombatState.surround;
            StateSwitch();
        }
        else if (!isCriticallyInjured)
        {
            state = CombatState.chase;
            StateSwitch();
        }
        else
        {
            state = CombatState.flee;
            StateSwitch();
        }

    }
}
