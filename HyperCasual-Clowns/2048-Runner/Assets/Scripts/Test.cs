using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector2 StartPosition;
    public Vector2 EndPosition;

    // starting value for the Lerp
    public float t = 0.0f;
    private void Start()
    {
        this.transform.position = new Vector2(0, Mathf.Lerp(StartPosition.y, EndPosition.y, t));

        t += 0.75f * Time.deltaTime;
    }

    void Update()
    {
       

        if(t > 1) 
        {
           
        }
    }
}
