using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierControl : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        transform.parent = player.transform;
        Physics.IgnoreLayerCollision(7, 12);
        Physics.IgnoreLayerCollision(8, 12);
    }

    // Update is called once per frame
    void Update()
    {   
        player = GameObject.FindGameObjectWithTag("player");
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(7, 12);
        Physics.IgnoreLayerCollision(8, 12);
        // Physics2D.IgnoreLayerCollision(11, 12);
        transform.parent = player.transform;
    }
}
