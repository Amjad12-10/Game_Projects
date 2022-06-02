using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool isMoving;
    StarManager Manager;
    private void Awake()
    {
        Manager = FindObjectOfType<StarManager>();
        
    }
    private void Start()
    {
        PosStart();
    }
    void PosStart(){
        this.transform.DOMoveX(7.5f,2,false).SetEase(Ease.Linear).OnComplete(() => PosEnd());

    }
    void PosEnd(){
        this.transform.DOMoveX(-2.5f,2,false).SetEase(Ease.Linear).OnComplete(() => PosStart());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Star") 
        {
            Debug.Log("Working");
            collision.transform.DOMoveY(-2,0.15f,false);
            Manager.Stars.Remove(collision.gameObject);
            Manager.Check();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }
}
