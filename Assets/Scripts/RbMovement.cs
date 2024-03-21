using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RbMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float moveInput;
    [SerializeField] private float speed = 5;
    //ground check stuff
    [SerializeField] private Transform groundCheck;
    private float jumpForce = 7;
    public bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    SceneManager sceneManager;

    OpenWireTask openWireTask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        openWireTask = FindObjectOfType<OpenWireTask>();
    }


    void FixedUpdate()
    {
        if (openWireTask.CanMove()) // Check if player can move
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero; // Stop player movement
        }
    }

    void Update()
    {
        if (openWireTask.CanMove() && Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Reset();
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
