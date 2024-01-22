using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceController : MonoBehaviour
{
    private Rigidbody2D rbody;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;


    [SerializeField] private LayerMask jumpableGround;

    private float moveX = 0f;
    [SerializeField] private float moveSpeed = 1.7f;
    [SerializeField] private float jumpForce = 7f;

    private enum MovementState { iceidle, walkright, jumpright }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal"); // Enables horizontal movement key; raw makes immediate stop occur.
        rbody.velocity = new Vector2(moveX * moveSpeed, rbody.velocity.y); // Move velocity

        if (Input.GetButtonDown("Jump") && IsGrounded()) // Enables jump key while grounded
        {
            jumpSoundEffect.Play();
            rbody.velocity = new Vector2(rbody.velocity.x, jumpForce); // Jump velocity
        }

        if (Input.GetKey("escape")) // Press escape to close game
        {
            Application.Quit();
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (moveX > 0f) // Move right
        {
            state = MovementState.walkright;
            sprite.flipX = false;
        }
        else if (moveX < 0f) // Move left
        {
            state = MovementState.walkright;
            sprite.flipX = true;
        }
        else // Idle
        {
            state = MovementState.iceidle;
        }
        
        if (rbody.velocity.y > .1f) // Checks if in air, with a margin of error.
        {
            state = MovementState.jumpright; // Plays jump animation
        }
        else if (rbody.velocity.y < -.1f)
        {
            state = MovementState.jumpright; // Placeholder for fall animation
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded() // Checks if grounded before allowing player to jump
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); // Applys boxcast to char that checks for collision while on ground
    }
}
