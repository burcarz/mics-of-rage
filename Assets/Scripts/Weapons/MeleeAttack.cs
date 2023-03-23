using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    Rigidbody rb;

    public LayerMask playerLayer;
    public Transform player;

    public float attackRange = 3f;
    public Transform attackPoint;

    public float damage = 10;

    void Start()
    {   
        rb = GetComponentInParent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    void Attack()
    {   
        // play attack anim
        rb.constraints = RigidbodyConstraints.FreezePosition;
        // detect enemies
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);
        
        for (int i = 0; i < hitPlayer.Length; i++)
        {
            if (hitPlayer[i] != null)
            {
                Player tP = hitPlayer[i].GetComponent<Player>();
                float attackDist = Vector3.Distance(player.position, attackPoint.position);

                if (attackDist <= attackRange)
                {
                        // Debug.Log("damage");
                        tP.ReduceHealth(damage);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
