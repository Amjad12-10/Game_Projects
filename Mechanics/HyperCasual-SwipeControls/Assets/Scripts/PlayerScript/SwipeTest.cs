using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SwipeTest : MonoBehaviour
{
    [Header("Animator")]
    Animator Anim;
    Rigidbody _rb;
    Vector2 FirstT;
    Vector2 SecondT;
    Vector2 CurrentSwipe;
    float Coins = 0;

    [Header("Panels")]
    public GameObject DeadPanel;
    public GameObject WinPanel;
    public GameObject GamePanel;
    [SerializeField]  private Camera cam;
    [Header("others")]
    public Text score;
    public Text COins;
     public CamControl CamScript;
    public float speed = 20;
    public Animator Anim1;
    public Animator Anim2;
    public policeScript Police;
    void Start()
    {
        //CamScript = GetComponent<CamControl>();
        Anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();

    }
    void Update()
    {
        COins.text = "" + Coins;
        score.text = ""+Coins;
        Swipe();
    }
    void Swipe()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;  
       
        if (Input.GetMouseButtonDown(0))
        {
            FirstT = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            SecondT = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            CurrentSwipe = new Vector2((SecondT.x - FirstT.x), (SecondT.y - FirstT.y));

            CurrentSwipe.Normalize();

            if (CurrentSwipe.y > -0.5 && CurrentSwipe.y < 0.5 && CurrentSwipe.x > 0)
            {
               
                _rb.velocity = speed * Vector3.right;
            }

            if (CurrentSwipe.y > -0.5 && CurrentSwipe.y < 0.5 && CurrentSwipe.x < 0)
            {
                _rb.velocity = speed * Vector3.left;
            }

          

        }
    }
    void OnTriggerEnter(Collider Object)
    {
        if(Object.gameObject.tag == "Finish")
        {
            speed = 0;
            CamScript.speed = 0;
            WinPanel.SetActive(true);
            Anim.SetBool("Win",true);
            GamePanel.SetActive(false);
            Anim.SetBool("Run", false) ;


        }
        if (Object.gameObject.tag == "Enemy")
        {
            GamePanel.SetActive(false);
            speed = 0;
            //CamScript.speed = 0;
            DeadPanel.SetActive(true);
            Anim1.SetBool("Dead", true);
            Anim2.SetBool("Dead", true);
            Police.sp = 0;
            
        }
        if(Object.gameObject.tag == "Collect")
        {
            //Score++;
            Debug.Log(Coins++);
            Destroy(Object.gameObject);
        }
    }
    void Dead()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }


}
