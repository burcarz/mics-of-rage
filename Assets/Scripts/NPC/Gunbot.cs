using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunbot : Grunt
{
    // distance values
    public float dist;
    private float distToGrunts;
    private float distToEnviroment;


    public Transform GBfirePoint;
    public GameObject cannonPrefab;

    float timer;
    int waitTime = 3;
    // Start is called before the first frame update
    new public void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new public void Update()
    {
        // check range / shoot every three seconds
        base.Update();
        checkRange();
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            Shoot();
            timer = 0;
        }
    }

    void checkRange()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist >= 2 && dist <= 2.1)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;

        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    void Shoot()
    {
        Instantiate(cannonPrefab, GBfirePoint.position, GBfirePoint.rotation);
    }

}
