using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public int TargetNumber;
    [SerializeField] private List<GameObject> Holders;
    [SerializeField] private int MaxHolders;
    [SerializeField] private GameObject LevelComplete;

    private static int plates;
    [SerializeField] private LevelManager Manager;
    private void Awake()
    {
        Manager = FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Holder"))
        {
            if (other.GetComponent<FoodIteam>().TargetNumber == TargetNumber)
            {
                if (Holders.Contains(other.gameObject)) 
                {
                }
                else 
                {
                    Holders.Add(other.gameObject);
                }
            }
            Check();
            Manager.Check();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Holder"))
        {
            if (other.GetComponent<FoodIteam>().TargetNumber == TargetNumber)
            {
                if (Holders.Contains(other.gameObject))
                {
                    Holders.Remove(other.gameObject);
                }
            }
        }
    }    
    private void Check() 
    {
        if(Holders.Count == MaxHolders) 
        {
            plates++;
            PlayerPrefs.SetInt("Plate", plates);
        }
    }
}
