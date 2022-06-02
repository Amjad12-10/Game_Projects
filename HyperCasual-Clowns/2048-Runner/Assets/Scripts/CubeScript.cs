using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System;

public class CubeScript : MonoBehaviour
{
    //==============================================================CubeNumber
    //-------------------------------------------------------------------
    public int Number;
    int TempHolder;
    //======================================================================TextMeshPro
    //----------------------------------------------------------------------
    public  List<TextMeshPro>_TextMesh;

    CubeManager Manager;
    PlayerController Controller;
    public bool CollsionInfo;
    private void Awake()
    {
        TempHolder = (int)Mathf.Pow(2, Number);
        Manager = FindObjectOfType<CubeManager>();
        Controller = FindObjectOfType<PlayerController>();
        CheckNumber(Number);
    }                           //--------------------------------------------------------------------------------------Awake
    void Start()
    {
        TextSetUp();
     
    }                           //--------------------------------------------------------------------------------------Start
    private void CheckNumber(int number)
    {
        GetComponent<Renderer>().material.color = Manager.CubeColor[number - 1];
    }                           //------------------------------------------------------------------------------------CheckNumber
    void TextSetUp() 
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _TextMesh[i] = transform.GetChild(i).GetComponent<TextMeshPro>();
            _TextMesh[i].text = TempHolder.ToString();
        }
    }                           //-------------------------------------------------------------------------------------TextSetUp
    void Change()
    {
        Number++;
        TempHolder = (int)Mathf.Pow(2, Number);
        CheckNumber(Number);
        TextSetUp();
    }                           //----------------------------------------------------------------------------------------Change
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Multiply")
        {
            CubeScript OtherScript = collision.gameObject.GetComponent<CubeScript>();
            if (OtherScript.Number == Number)
            {
                Controller.CollectObjects.Remove(collision.gameObject);
                Controller.ObjectPosition();
                Change();
                Destroy(collision.gameObject);
                transform.DORotate(new Vector3(0,360, 0), 1f, RotateMode.FastBeyond360);
            }
                 //-----------------------------------------------------------------------------------Compare Cube Number
       
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Dead") 
        {
            Debug.Log("End");
            Controller.splineFollower.follow = false;
            for(int i = 0;i< Controller.CollectObjects.Count; i++) 
            {
                Controller.CollectObjects[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Controller.CollectObjects[i].GetComponent<Rigidbody>().AddExplosionForce(120, Controller.CollectObjects[i].transform.position,10, 1, ForceMode.Force);
            }

        }
    }

}


