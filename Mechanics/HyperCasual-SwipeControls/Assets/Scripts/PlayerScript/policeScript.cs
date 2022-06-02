using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float sp = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward* sp * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Police")
        {
            sp = 0;
        }
    }
}
