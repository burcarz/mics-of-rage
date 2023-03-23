using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{   
    public float speed = 30f;
    public float damage = 10;
    public Rigidbody rb;
    public GameObject cannonImpactEffect;
    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine(SelfDestruct());

        rb.velocity = transform.right * speed;
    }


    void OnTriggerEnter(Collider hitInfo)
    {
        NPC npc = hitInfo.GetComponent<NPC>();
        if (npc != null)
        {
            npc.ReduceHealth(damage);
        }
        Destroy(gameObject);
        PlayEffect();

        // Instantiate(cannonImpactEffect, transform.position, transform.rotation);
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
        PlayEffect();

        // Instantiate(cannonImpactEffect, transform.position, transform.rotation);
    }

    void PlayEffect()
    {
        Instantiate(cannonImpactEffect, transform.position, transform.rotation);
    }
}
