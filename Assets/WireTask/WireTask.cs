using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTask : MonoBehaviour
{
    public List<Color> wireColors = new List<Color>();

    public List<Wires> leftWires = new List<Wires>();
    public List<Wires> rightWires = new List<Wires>();

    private List<Color> avaiColors;
    private List<int> avaiLeftWireIndex;
    private List<int> avaiRightWireIndex;

    public Wires currentDraggedWire;
    public Wires currentHoveredWire;

    public bool isTaskComplete = false;

    private void Start()
    {
        avaiColors = new List<Color>(wireColors);
        avaiLeftWireIndex = new List<int>();
        avaiRightWireIndex = new List<int>();

        for (int i = 0; i < leftWires.Count; i++)
        {
            avaiLeftWireIndex.Add(i);
        }

        for (int i = 0; i < rightWires.Count; i++)
        {
            avaiRightWireIndex.Add(i);
        }

        while (avaiColors.Count > 0 && avaiLeftWireIndex.Count > 0 && avaiRightWireIndex.Count > 0)
        {
            Color pickedColor = avaiColors[Random.Range(0, avaiColors.Count)];
            int pickedLeftWireIndex = Random.Range(0, avaiLeftWireIndex.Count);
            int pickedRightWireIndex = Random.Range(0, avaiRightWireIndex.Count);

            leftWires[avaiLeftWireIndex[pickedLeftWireIndex]].SetColor(pickedColor);
            rightWires[avaiRightWireIndex[pickedRightWireIndex]].SetColor(pickedColor);

            avaiColors.Remove(pickedColor);
            avaiLeftWireIndex.RemoveAt(pickedLeftWireIndex);
            avaiRightWireIndex.RemoveAt(pickedRightWireIndex);
        }

        StartCoroutine(CheckTaskComplete());
    }

    private IEnumerator CheckTaskComplete()
    {
        while (!isTaskComplete)
        {
            int connectedWires = 0;
            for (int i = 0; i < rightWires.Count; i++)
            {
                if (rightWires[i].isSuccess)
                {
                    connectedWires++;
                }
            }

            if (connectedWires >= rightWires.Count)
            {
                gameObject.SetActive(false);
                Debug.Log("Completed");
            }
            else
            {
                Debug.Log("Incomplete");
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
