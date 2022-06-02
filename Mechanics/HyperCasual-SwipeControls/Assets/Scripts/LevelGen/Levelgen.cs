using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelgen : MonoBehaviour
{
    public GameObject Parent;
    public GameObject[] Child;
    [Header("No of Platforms")]
    public float Platforms = 10;
    [Header("PlatformDistance")]
    public float distance = 3;
    [Header("First")]
    public GameObject FirstPlatform;
    [Header("Last")]
    public GameObject LastPlatform;
    // Start is called before the first frame update
    void Start()
    {
        LevelGen();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LevelGen()
    {
        for(int i = 0; i < Platforms; i++)
        {
            if (i == 0)
            {
                Instantiate(FirstPlatform, new Vector3(0, 0, 0), Quaternion.identity, Parent.transform);
            }
            if( i > 0 && i < 9)
            {
                Instantiate(Child[Random.Range(0, Child.Length)], new Vector3(0, 0, i * distance), Quaternion.identity, Parent.transform);
            }
            if (i  > 8)
            {
                Instantiate(LastPlatform, new Vector3(0, 0, i * distance), Quaternion.identity, Parent.transform);
            }

            

        }
    }

}
