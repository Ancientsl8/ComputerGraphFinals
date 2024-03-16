using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWireTask : MonoBehaviour
{
    public GameObject wireTask;
    public GameObject exclamation;
    public GameObject UI;

    private bool inTriggerZone = false;

    private void Update()
    {
        if (inTriggerZone && Input.GetKeyDown(KeyCode.E))
        {
            wireTask.SetActive(true);
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UI.SetActive(false);
            wireTask.SetActive(false);
            exclamation.SetActive(false);
            inTriggerZone = false;
        }
    }
}
