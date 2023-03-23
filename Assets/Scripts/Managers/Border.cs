using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public Rigidbody2D rb;


    void OnTriggerEnter2D(Collider2D colInfo)
    {
        Debug.Log("yes");
    }
}
