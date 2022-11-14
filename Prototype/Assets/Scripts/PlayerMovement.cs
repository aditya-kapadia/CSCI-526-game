using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float moveSpeed = 15f;
    public Vector2 direction;
    private bool facingRight = true;

    [Header("Vertical Movement")]
    public float jumpSpeed = 12f;
    public float jumpDelay = 1f;
    private float jumpTimer;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    public Animator playerAnimation;
    public LayerMask groundLayer;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 2f;
    public float gravity = 1;
    public float fallMultiplier = 1f;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLength = 1.2f;
    public Vector3 colliderOffset;

    [Header("MeteorShower")]
    public bool meteorShowerActive = false;
    public RuntimeAnimatorController restController;
    public RuntimeAnimatorController walkController;
    public RuntimeAnimatorController jumpController;

    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        playerAnimation.runtimeAnimatorController = restController;
        // restController = Resources.Load("Assets/COPY SPRIGHT/2D Character - Astronaut/Animations/Player.anim") as RuntimeAnimatorController;
        // walkController = Resources.Load("Assets/COPY SPRIGHT/2D Character - Astronaut/Animations/walk_side.anim") as RuntimeAnimatorController;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);

        if(Input.GetButtonDown("Jump"))
        {
            jumpTimer = Time.time + jumpDelay;
        }

        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        

    }
    void FixedUpdate()
    {
        moveCharacter(direction.x);
        if (jumpTimer > Time.time && onGround)
        {
            Jump();
        }

        modifyPhysics();

    }
    void moveCharacter(float horizontal)
    {
        if (horizontal != 0)
        {
            //Debug.Log("Player moved");
            GameObject spawner = GameObject.FindGameObjectWithTag("SpawnPoint");
            if (spawner && !meteorShowerActive)
            {
                meteorShowerActive = true;
                spawner.GetComponent<MeteorShower>().StartMeteorShower();
            }

        }
        
        rb.AddForce(Vector2.right * horizontal * moveSpeed);

        if((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Flip();
        }
        if(Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
        if(onGround)
        {
            if (direction.x == 0)
            {
                playerAnimation.runtimeAnimatorController = restController;
            }
            else
            {
                playerAnimation.runtimeAnimatorController = walkController;
            }
        } else
        {
            playerAnimation.runtimeAnimatorController = jumpController;
        }
        /*
        if(direction.x == 0)
        {
            playerAnimation.runtimeAnimatorController = restController;
        } else
        {
            playerAnimation.runtimeAnimatorController = walkController;
        }
        */
        //animator.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        jumpTimer = 0;
    }
    void modifyPhysics()
    {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);
        if (onGround)
        {
            if (Mathf.Abs(direction.x) < 0.4f || changingDirections)
            {
                rb.drag = linearDrag *0.5f;
            }
            else
            {
                rb.drag = 0f;
            }
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.25f;
            if (rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;
            }
            else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }

}
