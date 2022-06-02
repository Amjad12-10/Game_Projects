using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Playerstate
{
    Move,
    Stop
}
public class PlayerManager : MonoBehaviour
{
    public _PlayerController PlayerMove;
    public Playerstate State;

   
    private void Start()
    {
        PlayerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<_PlayerController>();
    }
    
    void Update()
    {
        
   
    }
}
