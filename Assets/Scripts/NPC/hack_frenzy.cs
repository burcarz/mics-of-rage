using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hack_frenzy : StateMachineBehaviour
{
    private GameObject[] frenzyPoints;
    private GameObject[] frenzyPointsB;
    private GameObject currentPoint;
    public Rigidbody rb;
    public float speed = 10f;
    public float attackRange = 4f;
    // private Vector2 currentTarget;
    private Vector3 currentTarget;
    private Vector3 currentPos;
    private Vector3 newPos;
    int index;
    private bool nextB = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       frenzyPoints = GameObject.FindGameObjectsWithTag("hackNodes");
       frenzyPointsB = GameObject.FindGameObjectsWithTag("hackNodesB");
       rb = animator.GetComponentInParent<Rigidbody>();
       animator.GetComponentInParent<NPC>().invuln = true;
       updatePos();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentPos = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z);
        moveTowardPoint();
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.GetComponentInParent<NPC>().invuln = false;
    }


    // UPDATE FUNCTIONS TO SIMULATE HACK BOUNCING OFF THE WALLS
    void updatePos()
    {
       if (frenzyPoints != null)
       {
            index = Random.Range (0, frenzyPoints.Length);
            currentPoint = frenzyPoints[index];
            currentTarget = new Vector3(currentPoint.transform.position.x, currentPoint.transform.position.y, currentPoint.transform.position.z);
       }
    }

    void updatePosB()
    {       
        if (frenzyPointsB != null)
        {
            index = Random.Range (0, frenzyPointsB.Length);
            currentPoint = frenzyPointsB[index];
            currentTarget = new Vector3(currentPoint.transform.position.x, currentPoint.transform.position.y, currentPoint.transform.position.z);
        }
    }

    void moveTowardPoint()
    {
        newPos = Vector3.MoveTowards(rb.transform.position, currentPoint.transform.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        if (currentTarget == currentPos)
        {
           if (nextB)
           {
                updatePosB();
                nextB = false;
           }
           else
           {
                updatePos();
                nextB = true;
           }
        }
    }
}
