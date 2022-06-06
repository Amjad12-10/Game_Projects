using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    [SerializeField] GameObject MoveTo; 
    [SerializeField] GameObject SwapObjects;

    [SerializeField] string Name;
    [SerializeField] string ChildrenName;
    [SerializeField] string Symbol;

    private void Start()
    {
      //  NameChange();
    }

    public void SwapClick()
    {
            Vector3 ObjectsToSwapPos = MoveTo.transform.position;
            Vector3 SwapObjectPos = SwapObjects.transform.position;
            //ObjectToSwap[i].transform.position = SwapObjects[i].transform.position;
            SwapObjects.transform.position = ObjectsToSwapPos;
            MoveTo.transform.position = SwapObjectPos;
    }
}
