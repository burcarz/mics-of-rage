using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dash : Ability
{
    public float dashVelocity;
    private Vector3 velocity = Vector3.zero;

    float horizontalMove;
    float verticalMove;

    // public Rigidbody rb;

    [Range(0, 1.0f)]
    [SerializeField] float movementSmooth = 0.5f;

    [SerializeField] private float hSpeed = 40f;
    [SerializeField] private float vSpeed = 10f;

    public override void Activate(GameObject parent)
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        // rb.GetComponentInParent<Rigidbody>();

        Player player = parent.GetComponent<Player>();
        if (player.currentEnergy >= energyCost)
        {
            Vector3 targetVelocity = new Vector3(horizontalMove * hSpeed, 0, verticalMove * vSpeed);
            player.rb.velocity = Vector3.SmoothDamp(player.rb.velocity, targetVelocity, ref velocity, movementSmooth);

            player.invuln = true;
            player.ReduceEnergy(energyCost);
        }
        else {
            return;
        }
    }

    public override void BeginCooldown(GameObject parent)
    {
        Player player = parent.GetComponent<Player>();
        // player.speed = normSpeed;
        player.invuln = false;
        Debug.Log(player.invuln);
    }
}
