using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    public Transform[] doorTransforms;
    public Vector3[] moveDirections;
    public float doorMoveSpeed;

    private void Update()
    {
        if (doorTransforms != null)
        {
            return;
        }
    }

    public void OpenDoors()
    {
        for (int i = 0; i < doorTransforms.Length; i++)
        {
            //doorTransforms[i].gameObject.SetActive(false);
            Vector3 targetPos = doorTransforms[i].position + moveDirections[i] * -2f;
            StartCoroutine(MoveDoorCoroutine(doorTransforms[i], targetPos));
        }
    }

    private IEnumerator MoveDoorCoroutine(Transform doorTransform, Vector3 targetPos)
    {
        Vector3 startPos = doorTransform.position;

        float startTime = Time.time;
        float journeyLength = Vector3.Distance(startPos, targetPos);

        while (Time.time < startTime + (journeyLength / doorMoveSpeed))
        {
            float distanceCovered = (Time.time - startTime) * doorMoveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            doorTransform.position = Vector3.Lerp(startPos, targetPos, fractionOfJourney);
            yield return null;
        }

        doorTransform.position = targetPos;
    }
}
