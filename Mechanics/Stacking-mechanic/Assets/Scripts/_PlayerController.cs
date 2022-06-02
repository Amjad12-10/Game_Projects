using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _PlayerController : MonoBehaviour
{
    [Header("Player Movements")]
    public float sidemove;
    public float Move;
    public float lim;

    public Text Scr;
    //------------------------Touch
    float touchX;
    float touchz;
    bool isTouch;

    //-------------------------------Managers
    PlayerManager Manager;

    //--------------------------------Components
    Material Mat;
    Rigidbody rb;

    public bool hit;


  
    private void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isTouch = true;
        }
        if (!Input.GetMouseButton(0))
        {
            isTouch = false;
        }
    
    }
    private void FixedUpdate()
    {
        if (isTouch) 
        {
            touchX += Input.GetAxis("Mouse X") * sidemove * Time.deltaTime;
        }
        if(!isTouch)
        {
            touchX = transform.position.x;
        }
        touchz = transform.position.z;
        touchz += Move * Time.deltaTime;
        touchX = Mathf.Clamp(touchX, -(lim), lim);
        Status();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="FanBoy")
        {
          collision.gameObject.SetActive(false); 
        }
        if(collision.gameObject.tag == "Enemy") 
        {
            hit = true;
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
        }
      
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Drop")
        {
            gameObject.GetComponent<Collider>().enabled = false;
            Manager.State = Playerstate.Stop; 
            gameObject.GetComponent<_PlayerController>().enabled = false;
            Move = 0;

        }
    }
    void Status()
    {
        if (Manager.State == Playerstate.Stop)
        {
            Move = 0;
        }
        if (Manager.State == Playerstate.Move)
        {
            transform.position = new Vector3(touchX, transform.position.y, touchz);
        }

    }
 
}
