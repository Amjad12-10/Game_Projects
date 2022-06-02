using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectControl : MonoBehaviour
{
    [SerializeField]  GameObject clown;
    [SerializeField] GameObject collect;
    [SerializeField] _PlayerController Controller;
    // Start is called before the first frame update
    void Start()
    {
       
        clown = this.gameObject.transform.GetChild(0).gameObject;
        collect = this.gameObject.transform.GetChild(1).gameObject;
        //ontroller = GameObject.FindGameObjectWithTag("Clown").GetComponent<_PlayerController>();
        Controller = clown.GetComponent<_PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        Acti();
    }
    void Acti() 
    {
        if (collect.gameObject.active == false)
        {
            clown.gameObject.SetActive(true);
        }
        if(Controller.hit == true) 
        {
            Destroy(this.gameObject);
        }

       
    }
}
