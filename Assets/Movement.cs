using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    private float moveX;
    private float gravY = -0.03f;
    private float speed = 0.05f;
    Vector3 gravDir;
    Vector3 moveDir;
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Horizontal movement
        moveX = Input.GetAxis("Horizontal");
        //Creates Vector based on the input
        moveDir = new Vector3(moveX * speed, 0);
        //Update player position with movement vector
        playerTransform.position += moveDir;

        grounded = Physics2D.Raycast(transform.position, Vector3.down, .67f);
        if (grounded)
        {
            gravDir = new Vector3(0, 0);
        }
        else
        {
            gravDir = new Vector3(0, gravY);
        }
        playerTransform.position += gravDir;
    }
}
