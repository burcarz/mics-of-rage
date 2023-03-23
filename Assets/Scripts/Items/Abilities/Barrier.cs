using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Barrier : Ability
{
    public GameObject barrier;
    GameObject currentBarrier;
    Player player;

    public override void Activate(GameObject parent)
    {

        player = parent.GetComponent<Player>();
        Rigidbody rb = parent.GetComponent<Rigidbody>();
        Vector3 spawnSpot = new Vector3(
            rb.transform.position.x,
            rb.transform.position.y + 1f,
            rb.transform.position.z);
        currentBarrier = Instantiate(barrier, spawnSpot, rb.transform.rotation);
        currentBarrier.transform.parent = player.transform;
        player.invuln = true;
        player.ReduceEnergy(energyCost);
    }

    public override void BeginCooldown(GameObject parent)
    {
        player.invuln = false;
        Destroy(currentBarrier);
    }

}
