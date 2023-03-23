using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackWeapon : MonoBehaviour
{
    Animator animator;
    public float attackRange = 4f;
    public LayerMask playerLayer;
    public Transform attackPoint;
    public int lungeDamage = 5;
    public int frenzyDamage = 2;
    public int runDamage = 1;
    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        // detect enemies
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);
        
        for (int i = 0; i < hitPlayer.Length; i++)
        {
            if (hitPlayer[i] != null)
            {
                Player tP = hitPlayer[i].GetComponent<Player>();
                tP.ReduceHealth(lungeDamage);
            }
        }
    }

    public void RunAttack()
    {
        // detect enemies
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);
        
        for (int i = 0; i < hitPlayer.Length; i++)
        {
            if (hitPlayer[i] != null)
            {
                Player tP = hitPlayer[i].GetComponent<Player>();
                tP.ReduceHealth(runDamage);
            }
        }
    }

    public void FrenzyAttack()
    {
        // detect enemies
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);
        
        for (int i = 0; i < hitPlayer.Length; i++)
        {
            if (hitPlayer[i] != null)
            {
                Player tP = hitPlayer[i].GetComponent<Player>();
                tP.ReduceHealth(frenzyDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        else
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
        
    }
}
