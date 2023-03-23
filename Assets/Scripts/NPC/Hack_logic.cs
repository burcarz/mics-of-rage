using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack_logic : StateMachineBehaviour
{
    public float speed = 10f;
    Transform player;
    Rigidbody rb;

    private Vector3 target;
    private Vector3 realLocation;
    public float attackRange = 4f;

    private float dist;
    private float dist2;
    // public Vector2 target;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        rb = animator.GetComponentInParent<Rigidbody>();
        target = new Vector3(player.position.x, player.position.y, player.position.z);
        animator.GetComponentInParent<NPC>().invuln = true;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // hack.LookAtPlayer();
        Vector3 currentPos = new Vector3(rb.position.x, rb.position.y, player.position.z);
        realLocation = new Vector3(player.position.x, player.position.y, player.position.z);
        Vector3 newPos = Vector3.MoveTowards(rb.transform.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        dist = Vector3.Distance(player.position, rb.transform.position);
        // Debug.Log(dist);
        
        if (currentPos == realLocation)
        {
            animator.SetTrigger("lunge");
        }

        else if (dist <= 1.25f)
        {
            animator.SetTrigger("lunge");
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponentInParent<NPC>().invuln = false;
    }
}
