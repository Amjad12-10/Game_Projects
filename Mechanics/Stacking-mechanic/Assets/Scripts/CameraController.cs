using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Target.position;     
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(offset.x, offset.y,Target.position.z+offset.z);
    }
}
