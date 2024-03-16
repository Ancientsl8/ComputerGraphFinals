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
    [SerializeField] private float groundedValue;

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
        /*
        RaycastHit2D hit = Physics2D.Raycast(playerTransform.position, Vector2.down, 0.67f);
        if (hit.collider != null)
        {
            Debug.DrawRay(playerTransform.position, Vector2.down);
            float distance = Mathf.Abs(hit.point.y - playerTransform.position.y);
            Debug.Log(distance);
        }
        */
        grounded = Physics2D.Raycast(playerTransform.position, Vector2.down, groundedValue);
        Debug.DrawRay(playerTransform.position, Vector2.down);
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
