using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Plate[] Plates;
    [SerializeField] private Collider GroundCollider;
    private int PlateNumber;
    // Start is called before the first frame update
    void Awake()
    {
        Plates = FindObjectsOfType<Plate>();
        PlayerPrefs.SetInt("Plate", 0);
    }
    public void Check() 
    {
        PlateNumber = PlayerPrefs.GetInt("Plate");
        if(PlateNumber == Plates.Length) 
        {
            print("Win");
            GroundCollider.enabled = true;
        }
    }
}
