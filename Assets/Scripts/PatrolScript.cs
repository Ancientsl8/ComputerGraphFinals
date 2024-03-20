using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private float speed = 1f;
    private bool point;
    // Start is called before the first frame update
    void Start()
    {
        point = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == pointB.position.x)
        {
            point = true;
        }

        else if (transform.position.x == pointA.position.x)
        {
            point = false;
        }
    }

    private void FixedUpdate()
    {
        var step = speed * Time.deltaTime;

        if (point)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(pointA.position.x, transform.position.y, 0), step);
        }

        else if (!point)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(pointB.position.x, transform.position.y, 0) , step);
        }
    }
}
