using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increment : MonoBehaviour
{
    [Header("GameObjects")]
    public List<GameObject> Num;
    public GameObject Element;
    [Header("Related to the List and Platform")]
    public int Listsize;//------------------------------used in on trigger enter..
    public int pl;//------------------------Length of the platform...
   //---------------------------------------Private 
    int Indx;
    int pos;
    private void Awake()
    {
        Instantiate(Element);
    }
    public void btn() 
    {
        pos += 1;
        Instantiate(Element,new Vector3(pos*pl,0,0),Quaternion.identity);
        Indx += 1;
        if (Indx > Listsize) 
        {
            Indx = 0;
        }
    }
    private void Update()
    {
        Element = Num[Indx];
       // print(Element);
    }

}
