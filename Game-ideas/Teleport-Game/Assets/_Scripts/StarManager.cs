using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StarManager : MonoBehaviour
{
    public List<GameObject> Stars;

    public GameObject Jail;
    public GameObject Princess;


    private GameObject[] StarHolder;
    // Start is called before the first frame update
    private void Awake()
    {
        StarHolder = GameObject.FindGameObjectsWithTag("Star");
    }
    void Start()
    {
        Stars = new List<GameObject>(StarHolder);
    /*     for(int i =0; i < Stars.Count; i++) 
        {
            Stars[i].transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f),1.2f,1, 5).SetLoops(-1);
        } */
    }
    public void Check() 
    {
        if(Stars.Count == 0) 
        {
            Princess.SetActive(true);
            Jail.SetActive(false);
            
        }
    }
}
