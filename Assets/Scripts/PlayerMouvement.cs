using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public float moveSpeed = 15f;

    [SerializeField] private float jumpForce = 35f;
    [SerializeField] private float dashForce = 2;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D rb;
    private Vector3 velocity;

    private bool isGrounded = false;
    private bool canDash = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        Jump();
        Dash();
    }

    private void Move() 
    {
        // Movement
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

        // transform sprite for direction
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        Vector3 moveVelocity = moveInput.normalized * moveSpeed;

        Vector3 targetVelocity = new Vector2(moveVelocity.x, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }

    private void Jump() 
    {
        // Grounded Check (for jumping)
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.75f, groundMask);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Dash() 
    {
        if(isGrounded) 
        {
            canDash = true;
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            rb.AddForce(Input.GetAxisRaw("Horizontal") * Vector2.right * 1000f * dashForce);
            canDash = false;
        }
    }

    public void resetVelocity() 
    {
        rb.velocity = Vector3.zero;
    }
}
