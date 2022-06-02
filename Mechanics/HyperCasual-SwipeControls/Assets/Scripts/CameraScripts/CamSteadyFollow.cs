using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSteadyFollow : MonoBehaviour
{
    public GameObject Target;
    public Vector3 Offset;
    [SerializeField] float smoothSpeed;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPos = Target.transform.position + Offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position += new Vector3(transform.position.x, transform.position.y, desiredPos.z);
    }
}
