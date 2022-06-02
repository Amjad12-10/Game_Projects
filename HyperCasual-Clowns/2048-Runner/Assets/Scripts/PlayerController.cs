using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class PlayerController : MonoBehaviour
{
    //===============================================================================SwipeMoveent
    //------------------------------------------------------------------------------
    [Header("PlayerSwipeSpeed")]
    public float swipespeed;
    public SplineFollower splineFollower;
    bool isEditor = true;

    //================================================================================Collector
    //--------------------------------------------------------------------------------
    public GameObject BranchPlayer;
    public List<GameObject> CollectObjects;
    private float _deltaTime;

    float T = 1;

    private void Start()
    {
        splineFollower = GetComponent<SplineFollower>();
        CollectObjects.Add(BranchPlayer);
    }                                                                               //-----------------------------------------------------Start

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Same") 
        {
            try
            {
                collision.gameObject.tag = "Multiply";
                CollectObjects.Add(collision.gameObject);
                ObjectPosition();
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                collision.gameObject.transform.parent = this.transform;
            }
            catch(Exception e) { }
        }                                                                             //-----------------------------------------------------Same 
    }

    public void ObjectPosition()
    {
          for(int y = 0; y < CollectObjects.Count; y++) 
          {
              y = Mathf.CeilToInt(y);
             CollectObjects[y].transform.position = new Vector3(transform.position.x, y +2.5f, transform.position.z);
          }

    }   
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Movement();
        }
    }

    #region Movement
    private void Movement()
    {
        if (isEditor)
        {
           // swipespeed = 50;
            float rotX = Input.GetAxis("Mouse X") * swipespeed * Mathf.Deg2Rad;
            Vector2 pos = new Vector3(rotX * Time.deltaTime, 0);
            splineFollower.motion.offset += pos;
            splineFollower.motion.offset = new Vector3(Mathf.Clamp(splineFollower.motion.offset.x, -2,2), 1, 0);
        }
        else
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                float rotX = touchDeltaPosition.x * swipespeed * Mathf.Deg2Rad;
                Vector2 pos = new Vector3(rotX * Time.deltaTime,0);
                Debug.Log(pos);
                splineFollower.motion.offset += pos;
                splineFollower.motion.offset = new Vector3(Mathf.Clamp(splineFollower.motion.offset.x,-2, 2), 1, 0);
            
            }
        }
    }
    #endregion Movement

}
