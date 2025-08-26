using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed;
    public float JumpForce;
    public Transform CeilingCheck;
    public Transform GroundCheck;
    public LayerMask GroundObjects;
    public float CheckRadius;

    private Rigidbody2D rb;
    private bool FacingRight = true;
    private float MoveDirection;
    private bool IsJumping = false;
    private bool IsGrounded;

    // Called after objects are intialized. Called in a random order.
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // will look for a component on the GameObject (what this script is attached to)
    }

    // Update is called once per frame, better for inputs/drawing things to screen
    void Update()
    {
        // Get inputs
        ProcessInputs();

        // Animate
        Animate();
    }

    // Better for handling physics as it can be called multiple times per frame
    private void FixedUpdate()
    {
        // Check if grounded
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, GroundObjects);

        // Move
        Move();
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(MoveDirection * MoveSpeed, rb.linearVelocity.y);
        if (IsJumping)
        {
            rb.AddForce(new Vector2(0f, JumpForce));
        }
        IsJumping = false;
    }

    private void Animate()
    {
        if (MoveDirection > 0 && !FacingRight)
        {
            FlipCharacter();
        }
        else if (MoveDirection < 0 && FacingRight)
        {
            FlipCharacter();
        }
    }

    private void ProcessInputs()
    {
        MoveDirection = Input.GetAxis("Horizontal");  // Scale of -1 to 1 (left is -1, right is 1)
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            IsJumping = true;
        }
    }

    private void FlipCharacter()
    {
        FacingRight = !FacingRight; // Inverse bool
        transform.Rotate(0f, 180f, 0f); // Flips the character lol
    }
}
