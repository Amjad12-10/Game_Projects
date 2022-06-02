using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Bullet : MonoBehaviour
{
    private GameObject PlayerTransform;
    public GameObject SwitchObject;
    public GameObject MainPlayer;
    
    public float speed;
    public int DirectionNumber;
    public Vector3 Direction;

    [SerializeField]
    public static float angle;

    private Gun Main;

   
    // Start is called basdadefore the first frame update
    void Start()
    {
        Main = FindObjectOfType<Gun>();
    
        Direction = Main.transform.GetChild(0).up;
       
    }

    // Update is called once per frame
    void Update()
    {

       transform.position += Direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SwitchObject")
        {
            DOTween.Clear();
            print("I'm Working");
            PlayerTransform = GameObject.FindGameObjectWithTag("Player");
            GameObject Instance = Instantiate(SwitchObject,new Vector3(PlayerTransform.transform.position.x,PlayerTransform.transform.position.y,PlayerTransform.transform.position.z), Quaternion.identity);
            Instance.GetComponent<Enemy>().enabled = false;
            Instantiate(MainPlayer, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject, 0.005f);
            Destroy(PlayerTransform, 0.005f);
            Destroy(this.gameObject, 0.005f);
        }
    }
}
