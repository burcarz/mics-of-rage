using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thug : NPC
{
    public Text stateText;

    float x;
    float y;
    float z;
    public float meleeRange = 1f;

    public int shotsSinceLastAdvance;
    public bool canShoot = false;

    public Transform TfirePoint;
    public GameObject cannonPrefab;

    // ADD ADDITIONAL COMBAT STATES
    public enum CombatState {
        advance,
        halt,
        shoot,
        melee,
    }

    CombatState state = CombatState.advance;

    new public void Start()
    {
        base.Start();
        isThug = true;
    }

    new public void Update()
    {
        base.Update();
        StateManager();
        stateText.text = state.ToString();
        InvokeRepeating("checkThreatLevel", 1f, 1f);
    }

    public void StateSwitch()
    {
        // ADD ADDITIONAL CASES FOR THUG STATES
        switch (state)
        {
            case CombatState.advance:
                    Advance();
            break;
            case CombatState.halt:
                    Halt();
            break;
            case CombatState.shoot:
                    Shoot();
            break;
            case CombatState.melee:
                    Melee();
            break;
            default: Advance();
            break;
        }
    }

    public void StateManager()
    {
        if (this.playerThreatValue > 3f
        && shotsSinceLastAdvance < 3
        && !this.isWaiting)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isMelee", false);
            state = CombatState.shoot;
        }
        else if (this.playerThreatValue > 1.5f && !canShoot)
        {
            animator.SetBool("isShooting", false);
            animator.SetBool("isMelee", false);
            state = CombatState.advance;
        }
        else if (this.isWaiting)
        {
            state = CombatState.halt;
        }
        else if (this.playerThreatValue < 1.5f)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isShooting", true);
            state = CombatState.melee;
        }
        StateSwitch();
    }

    public void Shoot()
    {
        animator.SetBool("isShooting", true);
        agent.SetDestination(rb.transform.position);
        this.isAggro = 1;

        Instantiate(cannonPrefab, TfirePoint.position, TfirePoint.rotation);

        if (shotsSinceLastAdvance == 1)
        {
            shotsSinceLastAdvance += 1;
        }
        else
        {
            shotsSinceLastAdvance = 1;
        }
        IEnumerator StartWaiting()
        {
            this.isWaiting = true;
            yield return new WaitForSeconds(1.5f);
            this.isWaiting = false;
        }
        StartCoroutine(StartWaiting());
    }

    public void Melee()
    {
        animator.SetBool("isMelee", true);
        // replace with animation exec
    }

    public void Halt()
    {
        agent.SetDestination(rb.transform.position);
        this.isAggro = 0;

        if (shotsSinceLastAdvance == 2)
        {
            shotsSinceLastAdvance = 0;
        }
    }



    public void Advance()
    {
        this.isAggro = 1;

        x = player.position.x + 1;
        y = 0;
        z = Random.Range(player.position.z - 1, player.position.z + 1);
        Vector3 target = new Vector3(x, y, z);
        agent.SetDestination(target);

        animator.SetBool("isMoving", true);
    }
}
