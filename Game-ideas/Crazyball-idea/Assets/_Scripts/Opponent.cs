using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    bool isfollow = false;
    private float speed = 4;
    public Transform Target;
    [HideInInspector]public Animator Anim;
    private void Start()
    {
        Anim = GetComponentInChildren<Animator>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isfollow = true;
            Anim.SetInteger("Running", 1);
        }
    }
    private void Update()
    {
        transform.LookAt(Target.transform);
        if (isfollow) 
        {
            this.transform.position += Vector3.forward * speed * Time.deltaTime;
          
        }
    }
}
