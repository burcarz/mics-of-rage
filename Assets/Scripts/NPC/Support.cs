using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Support : NPC
{
    public Text stateText;

    float x;
    float y;
    float z;

    bool allyInRange;
    bool isChanneling = false;
    bool channelBroken = false;
    bool canChannel = true;

    float channelCoolTime = 5f;
    float distToNearestAlly;
    float distToAlly;

    float distToTarget;
    int beamLength;
    float lerpValue;

    Vector3 instPos;

    public GameObject saviorBeam;
    public Transform beamPoint;

    public GameObject beamSprite;
    public Beam beam;

    [SerializeField] GameObject beamStart;
    [SerializeField] GameObject beamEnd;
    [SerializeField] GameObject shieldSprite;

    NPC nearestAlly;
    NPC selectedAlly;
    NPC shieldTarget;

    List<NPC> activeAllies = new List<NPC>();

    public enum CombatState {
        follow,
        flee,
        cover,
        channelSearch,
        channelActive,
    }

    CombatState state = CombatState.follow;

    new public void Start()
    {
        base.Start();
        isSupport = true;
        isChanneling = false;
        channelBroken = false;
        canChannel = true;

        if (AIManager.Instance)
        {
            activeAllies = AIManager.Instance.activeAllies;
        }
    }

    
    new public void Update()
    {
        base.Update();
        StateManager();
        if (activeAllies.Count >= 1)
        {
            DistanceToAllies(activeAllies);
        }
        stateText.text = state.ToString();
    }

    public void StateSwitch()
    {
        // ADD ADDITIONAL CASES FOR THUG STATES
        switch (state)
        {
            case CombatState.follow:
                    Follow();
            break;
            case CombatState.channelSearch:
                    Channel(activeAllies);
            break;
            case CombatState.flee:
                    Flee();
            break;
            case CombatState.channelActive:
                    ActiveChannel(shieldTarget);
            break;
            default: Follow();
            break;
        }
    }

    public void StateManager()
    {
        if (isChanneling && canChannel)
        {
            state = CombatState.channelActive;
            StateSwitch();
            return;
        }
        if (channelBroken)
        {
            state = CombatState.flee;
            StateSwitch();
            return;
        }
        FindNearest(activeAllies);
        if (activeAllies.Count >= 1)
        {
            if (activeAllies.Count >= 1 && canChannel)
            {
                state = CombatState.channelSearch;
                StateSwitch();
                return;
            }
            else if (activeAllies.Count >= 1 || this.playerIsThreat == 1)
            {
                state = CombatState.follow;
                StateSwitch();
                return;
            }
        }
        else
        {
            state = CombatState.flee;
            StateSwitch();
            return;
        }
        StateSwitch();
    }

    public void Follow()
    {
        FindNearest(activeAllies);
        if (nearestAlly)
        {
            x = Random.Range(nearestAlly.transform.position.x + 2, nearestAlly.transform.position.x + 3);
            y = 0;
            z = nearestAlly.transform.position.z;
            Vector3 moveTarget = new Vector3(x, y, z);
            agent.SetDestination(moveTarget);
        }
    }

    public void Channel(List<NPC> allies)
    {
        foreach (NPC npc in allies) 
        {
            if (
                npc.isThug && 
                !this && 
                !npc.isShielded &&
                npc.supportNearby == 1 ||
                npc.playerIsThreat == 1
            )
            {
                // Debug.Log("case 1" + " " + npc);
                CreateShield(npc);
            }
            else if (npc.isThug &&
                    !npc.isShielded &&
                    !this)
            {
                // Debug.Log("case 2" + " " + npc);
                CreateShield(npc);
            }
            else if (npc.isGrunt &&
                    !npc.isShielded &&
                    npc.hasTakenDamage == 1 ||
                    npc.playerIsThreat == 1 ||
                    !this)
            {
                // Debug.Log("case 3" + " " + npc);
                CreateShield(npc);
            }
            else if (npc.isGrunt &&
                    !npc.isShielded &&
                    npc.supportNearby == 1 ||
                    !this)
            {
                // Debug.Log("case 4" + " " + npc);
                CreateShield(npc);
            }
            else
            {
                Follow();
            }
        }
    }

    public void Flee()
    {
        if (allyInRange)
        {
            Follow();
            return;
        }
        x = Random.Range(player.transform.position.x + 1, player.transform.position.x + 3);
        y = 0;
        z = Random.Range(player.transform.position.z - 1, player.transform.position.z + 1);
        Vector3 moveTarget = new Vector3(x, y, z);
        agent.SetDestination(moveTarget);
    }

    public void CreateShield(NPC target)
    {
        if (isChanneling || target.isShielded)
        {
            return;
        }
        Debug.Log(target);
        target.isShielded = true;
        target.maxShields = 20;
        target.currentShields = target.maxShields;

        shieldsDisplay.text = target.ToString();

        // must have selected target and generated shields to be put in channeling stance
        shieldTarget = target;
        isChanneling = true;
        state = CombatState.channelActive;
        target.shieldsDisplay.text = target.currentShields.ToString();

        Vector3 shieldPos = new Vector3(target.transform.position.x - .3f, 
                                        target.transform.position.y,
                                        target.transform.position.z);
        
        // create shield sprite on target
        Instantiate(shieldSprite, shieldPos, target.transform.rotation, target.transform);
    }

    public void ActiveChannel(NPC target)
    {
        // distToTarget = Vector3.Distance(target.transform.position, rb.transform.position);

        if (!beamSprite.activeSelf)
        {
            beamSprite.SetActive(true);
            // beamStart.SetActive(true);
            // beamEnd.SetActive(true);
        }

        // beamStart.transform.position = target.transform.position;

        beam.GenerateBeam(target.transform);


        beamStart.transform.position = new Vector3(beam.end.position.x, 
                                                   beam.end.position.y + 1,
                                                   beam.end.position.z);

        animator.SetBool("isChanneling", true);
        Follow();
        Debug.DrawLine(target.transform.position, rb.transform.position, Color.blue);
        // Instantiate(saviorBeam, beamPoint.position, beamPoint.rotation);
        if (target.currentShields <= 0)
        {
            Debug.Log("broken " + isChanneling);
            isChanneling = false;
            channelBroken = true;
            canChannel = false;
            target.isShielded = false;
            target.shieldsDisplay.text = "Broke";
            animator.SetBool("isChanneling", false);
            beamSprite.SetActive(false);
            // beamStart.SetActive(false);
            // beamEnd.SetActive(false);

            IEnumerator ChannelCoolDown()
            {
                yield return new WaitForSeconds(2f);
                shieldsDisplay.text = "Shield";
                channelBroken = false;
            }

            IEnumerator SecondaryCoolDown()
            {
                yield return new WaitForSeconds(channelCoolTime);
                shieldsDisplay.text = "Channel";
                canChannel = true;
            }

            StartCoroutine(ChannelCoolDown());
            StartCoroutine(SecondaryCoolDown());
        }
    }

    public void FindNearest(List<NPC> allies)
    {
        distToNearestAlly = Mathf.Infinity;
        foreach (NPC npc in allies)
        {
            if (npc)
            {
                distToAlly = Vector3.Distance(npc.transform.position, rb.transform.position);

                if (distToAlly < distToNearestAlly && !npc.isSupport)
                {
                    nearestAlly = npc;
                    distToNearestAlly = distToAlly;
                    allyInRange = true;
                    npc.supportNearby = 1;
                    // Debug.DrawLine(nearestAlly.transform.position, rb.transform.position, Color.red);
                }
                else
                {
                    allyInRange = false;
                    npc.supportNearby = 0;
                }
            }
        }
        // Debug.Log(nearestAlly + " is the closest ally");
    }
}
