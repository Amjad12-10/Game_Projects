using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Cube : MonoBehaviour
{
    public float maxLength = 2;
    public float speed;
    public int TextNumber;
    //------------ Vectors
    private Vector3 StartPosition, EndPosition;
    private Vector3 Directions;
    private Vector3 moveDirection;
    //------------ Rigibody
    private Rigidbody Rb;
    // Start is called before the first frame update
    void Start()
    {
        Rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //------------- MouseDown
        if (Input.GetMouseButtonDown(0))
        {
            StartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        //------------- MouseUp
        if (Input.GetMouseButtonUp(0))
        {
            EndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (EndPosition != StartPosition)
            {
                SwipeDirection();
            }
            StartPosition = Vector3.zero;
        }
    }
    private void SwipeDirection()
    {
        //------------- SwipeDistance
        float Dir = Vector3.Distance(StartPosition, EndPosition);
        Directions = EndPosition - StartPosition;

        //------------- SwipeLimit
        if (Dir >= maxLength)
        {
            //------------- SwipeRight || SwipeLeft
            if ((Directions.z > 2 || Directions.z < -2))
            {
                if (EndPosition.z > StartPosition.z)
                {
                    moveDirection = Vector3.forward;
                    print("Up");
                }
                else
                {
                    moveDirection = Vector3.back;
                    print("Down");

                }
            }
            //------------- SwipeUp || SwipeDown
            else if ((Directions.x > 2 || Directions.x < -2))
            {
                if ((EndPosition.x > StartPosition.x))
                {
                    moveDirection = Vector3.right;
                    print("right");
                }
                else
                {
                    moveDirection = Vector3.left;
                    print("left");
                }
            }
            Movement();
        }
    }
    private void Movement()
    {
        Rb.velocity = moveDirection * speed;
    }

}
