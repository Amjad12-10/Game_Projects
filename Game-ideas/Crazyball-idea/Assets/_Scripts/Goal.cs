using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private Ball _ball;
    private Opponent[] _opponent;

    public GameObject Celebrate;

    MenuScript Menu;
    GameScript _Game;

    private void Awake()
    {
        _Game = FindObjectOfType<GameScript>();
        Menu = FindObjectOfType<MenuScript>();
        _ball = FindObjectOfType<Ball>();
        _opponent = FindObjectsOfType<Opponent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            _Game.Onwin();
           // Menu.levesel++;
          //  PlayerPrefs.SetInt("Level", Menu.levesel);
            Celebrate.SetActive(true);
            _ball.enabled = false;
            for(int i = 0; i < _opponent.Length; i++) 
            {
              _opponent[i].Anim.SetBool("Loss", true);
             _opponent[i].enabled = false;

            }
        }
    }
}
