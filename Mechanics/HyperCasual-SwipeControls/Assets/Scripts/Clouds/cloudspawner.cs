using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudspawner : MonoBehaviour
{
    public GameObject[] Cloud;
    public GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Cloud[Random.Range(0,Cloud.Length)], Parent.transform.position, Quaternion.identity);
        InvokeRepeating("Clouds",30, 30);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void Clouds()
    {
        Instantiate(Cloud[Random.Range(0, Cloud.Length)], Parent.transform.position, Quaternion.identity);
    }
}
