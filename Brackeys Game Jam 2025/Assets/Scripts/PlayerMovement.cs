using System.Collections;
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
    private bool CanDash = true;
    private bool IsDashing;
    private float DashingPower = 24f;
    private float DashingTime = 0.2f;
    private float DashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

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

        // Makes sure the player can't move while dashing
        if (IsDashing)
        {
            return;
        }
    }

    // Better for handling physics as it can be called multiple times per frame
    private void FixedUpdate()
    {
        // Check if grounded
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, GroundObjects);

        // Makes sure the player can't move while dashing
        if (IsDashing)
        {
            return;
        }

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
        if (Input.GetKeyDown(KeyCode.LeftShift) && CanDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void FlipCharacter()
    {
        FacingRight = !FacingRight; // Inverse bool
        transform.Rotate(0f, 180f, 0f); // Flips the character lol
    }

    private IEnumerator Dash()
    {
        CanDash = false;
        IsDashing = true;
        float OriginalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(MoveDirection * DashingPower, 0);
        tr.emitting = true;
        yield return new WaitForSeconds(DashingTime);
        tr.emitting = false;
        rb.gravityScale = OriginalGravity;
        IsDashing = false;
        yield return new WaitForSeconds(DashingCooldown);
        CanDash = true;
    }
}
