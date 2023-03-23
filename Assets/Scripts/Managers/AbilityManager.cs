using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    float activeTime;
    public Animator animator;
    Player player;
    enum AbilityState {
        ready,
        active,
        cooldown
    }

    AbilityState state = AbilityState.ready;

    // Update is called once per frame
    void Update()
    {
        Player player = GetComponent<Player>();
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetButtonDown("ability") && player.currentEnergy >= ability.energyCost)
                {
                    Casting();
                    ability.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                }  
            break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    ability.Active(gameObject);
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    ability.BeginCooldown(gameObject);
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                }
            break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
            break;
        }




    }

    public void Casting()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetTrigger("casting");
    }
}
