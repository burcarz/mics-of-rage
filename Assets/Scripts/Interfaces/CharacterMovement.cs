using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement: MonoBehaviour
{
    [SerializeField] private float hSpeed = 10f;
    [SerializeField] private float vSpeed = 5f;
    [SerializeField] private float jSpeed = 1.0f;
    [SerializeField] private bool canMove = true;

    // private Vector3 jump = Vector3.zero;

    private bool facingRight = true;
    private Rigidbody rb;

    [Range(0, 1.0f)]
    [SerializeField] float movementSmooth = 0.5f;
    private Vector3 velocity = Vector3.zero;
    public Vector3 jumpDir;
    public Vector3 fallDir;
    private Vector3 basePos;

    public bool onGround = true;

    public Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Awake()
    {
        basePos = new Vector3(0f, 0.1f, 0f);
        jumpDir = new Vector3(0.0f, 25.0f, 0.0f);
        fallDir = new Vector3(0.0f, -1.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void OnCollisionStay()
    {
        onGround = true;
        canMove = true;
    }

    void Update()
    {
            if (Input.GetButtonDown("Jump") && onGround)
            {
                rb.AddForce(jSpeed * jumpDir, ForceMode.Impulse);
                onGround = false;
                canMove = false;
            }
            else if (!onGround || transform.position.y > basePos.y)
            {
                rb.AddForce(jSpeed * fallDir, ForceMode.Impulse);
            }
    }

    // Update is called once per frameaa
    public void Move(float hMove, float vMove, float jMove, bool jump)
    {
        // check if the player character can jump;
        if (canMove)
        {
                Vector3 targetVelocity = new Vector3(hMove * hSpeed, 0, vMove * vSpeed);
                AnimateMovement(targetVelocity);
                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmooth);

            if (hMove > 0 && !facingRight)
            {
                FlipRight();
            }
            else if (hMove < 0 && facingRight)
            {
                FlipLeft();
            }
        }
    }


    public void AnimateMovement(Vector3 direction)
    {
        if (direction.x > 0 || direction.z > 0) {
            animator.SetLayerWeight(1,1);
        }
        else if (direction.x < 0 || direction.z < 0) {
            animator.SetLayerWeight(1,1);
        }
        else {
            animator.SetLayerWeight(1,0);
        }
    }

    private void FlipLeft()
    {
            facingRight = false;
            transform.Rotate(0f, 180f, 0f);
            spriteRenderer.transform.Rotate(-90f, 0f, 0f);
            // transform.localScale = flipped;
    }

    private void FlipRight()
    {
            facingRight = true;
            transform.Rotate(0f, 180f, 0f);
            spriteRenderer.transform.Rotate(90f, 0f, 0f);
    }
}
