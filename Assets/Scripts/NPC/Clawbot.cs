using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clawbot : Grunt
{
    public float dist;
    public float dist2;

    public Transform attackPoint;
    public float attackRange = .5f;


    new public void Start()
    {
        base.Start();
    }

    new public void Update()
    {
        base.Update();
    }

    public void FixedUpdate()
    {
        checkRange();
    }

    void checkRange()
    {
        float dist = Vector3.Distance(player.position, rb.transform.position);
        // Debug.Log(player.position);

            if (dist <= attackRange && !isStunned)
            {
                rb.constraints = RigidbodyConstraints.FreezePosition;
                animator.SetTrigger("prep");
                
            }
            else
            {
                animator.SetTrigger("chase");
                rb.constraints = RigidbodyConstraints.None;
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
