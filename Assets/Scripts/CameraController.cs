using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 targetPoint = Vector3.zero;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float moveSpeed;
    public RbMovement rbMovement;
    public float lookAheadDistance = 2f, lookAheadSpeed = 3f;
    private float lookOffset;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = new Vector3(playerPosition.transform.position.x, playerPosition.transform.position.y, -1);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //if player is in the air, update the camera
        if (rbMovement.isGrounded)
        {
            targetPoint.y = playerPosition.transform.position.y;
        }
        
        //Checks to see if player is moving right or left (positive is going right, negative is going left)
        if(rbMovement.rb.velocity.x > 0)
        {
            //Sets the camera viewpoint to the right of the player
            lookOffset = Mathf.Lerp(lookOffset, lookAheadDistance, lookAheadSpeed * Time.deltaTime);
        }

        if (rbMovement.rb.velocity.x < 0)
        {
            //Sets the camera viewpoint to the left of the player
            lookOffset = Mathf.Lerp(lookOffset, -lookAheadDistance, lookAheadSpeed * Time.deltaTime);
        }

        if (rbMovement.rb.velocity.x == 0)
        {
            //Sets the camera viewpoint to the left of the player
            lookOffset = Mathf.Lerp(lookOffset, 0, lookAheadSpeed * Time.deltaTime);
        }
        //moves the point where the camera follows based on movement;
        targetPoint.x = playerPosition.transform.position.x + lookOffset;

        //moves camera to follow the point
        transform.position = Vector3.Lerp(transform.position, targetPoint, moveSpeed * Time.deltaTime);
    }
}
