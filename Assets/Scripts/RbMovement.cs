using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float moveInput;
    [SerializeField]private float speed = 5;
    //ground check stuff
    [SerializeField] private Transform groundCheck;
    private float jumpForce = 7;
    public bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
