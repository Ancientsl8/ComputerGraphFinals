using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWireTask : MonoBehaviour
{
    public GameObject wireTask;
    public GameObject exclamation;
    public GameObject UI;

    private bool inTriggerZone = false;
    private bool canMove = true;

    public void EnablePlayerMovement()
    {
        canMove = true; // Enable player movement when wire task is completed
    }

    private void Update()
    {
        if (inTriggerZone && Input.GetKeyDown(KeyCode.E))
        {
            wireTask.SetActive(true);
            canMove = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            exclamation.SetActive(true);
            UI.SetActive(true);
            inTriggerZone = true;
        }
    }

    public bool CanMove()
    {
        return canMove;
    }
}
