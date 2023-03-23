using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack : NPC
{
    public bool faceLeft = true;

    new void Start()
    {
        base.Start();
    }
    
    new public void Update()
    {
        IsAlive();
        // base.Update();
    }

    void FixedUpdate()
    {
        IsAlive();
        FlipAround();
    }

    void FlipAround()
    {
        Debug.Log("flip called");
        if (player.position.x > transform.position.x && faceLeft)
        {
            faceLeft = false;
            // transform.Rotate(0f, 180f, 0f);
            // spriteRenderer.transform.Rotate(-90f, 180f, 0f);
            transform.rotation = Quaternion.Euler(-90, 180, 0);
            return;
        }
        else if (player.position.x < transform.position.x && !faceLeft)
        {
            faceLeft = true;
            // transform.Rotate(0f, 180f, 0f);
            // spriteRenderer.transform = Rotate(90f, 180f, 0f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            return;
        }
    }
}
