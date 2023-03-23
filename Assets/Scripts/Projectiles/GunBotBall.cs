using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBotBall : MonoBehaviour
{   
    public float speed = 30f;
    public int damage = 10;
    public Rigidbody rb;
    public GameObject cannonImpactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(SelfDestruct());
    }
    void OnTriggerEnter(Collider hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        Debug.Log("player hit");
        if (player != null)
        {
           player.ReduceHealth(damage);
           Destroy(gameObject);
           Instantiate(cannonImpactEffect, transform.position, transform.rotation);
        }
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("BALL DESTROYED");
        Destroy(gameObject);

        Instantiate(cannonImpactEffect, transform.position, transform.rotation);
    }
}
