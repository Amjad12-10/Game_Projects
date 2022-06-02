using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public float swipeSpeed;
    private Rigidbody Rb;

    public GameObject flash;

    private int Direction;


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Direction = Random.Range(0, 1);
    }

    void DirectionChange() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(flash,new Vector3(this.transform.position.x,0.25f,this.transform.position.z-0.25f),Quaternion.Euler(0,180,0),this.transform);
            if (Direction == 0)
            {
                Direction = 1;
            }
            else if (Direction == 1)
            {
                Direction = 0;
            }
        }
        if (Direction == 0)
        {
            Rb.velocity = Vector3.right * swipeSpeed;
        }
        else if (Direction == 1)
        {
            Rb.velocity = -Vector3.right * swipeSpeed;
        }
    }
    private void Update()
    {
        DirectionChange();
    }
    private void FixedUpdate()
    {
       transform.position  += Vector3.forward * speed * Time.deltaTime;
       transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5, 5),transform.position.y,transform.position.z);
    }
}
