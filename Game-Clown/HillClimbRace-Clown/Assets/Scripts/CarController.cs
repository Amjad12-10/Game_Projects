using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    [Header("PHYSICS")]
    public Rigidbody2D WheelR;
    public Rigidbody2D Body;
    public float _Torque;
    public float Speed;

    [Header("FUEL")]
    public Image tank;
    public SpriteRenderer TankSprite;

    [Header("Progreesion")]
    public Image Progress;
    float CarX;
    float IncrI = 0;
    int Lev = 1;
    public Text LevelNUm;

    [Header("Scripts")]
    public Increment Spawn;

    [Header("UI Images")]
    public GameObject I_Gas;
    public GameObject I_Break;
    //----------------------------------------------Private
    [SerializeField]bool GAs;
    [SerializeField] bool BReak;
    [Header("FuelTank")]
    int GAses;
    float fuel = 1;
    public float fuelconsumption = 0.01f;
    //----score
    [Header("Score")]
    public Text ScoreTxt;
    float score;
    
    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        
    }
    // Update is called once per frame
    void Update()
    {
        LevelNUm.text = "" + Lev;
        Move();
        ScoreTxt.text = score.ToString();
       
    }
    private void FixedUpdate()
    {
        fuel -= fuelconsumption * Time.fixedDeltaTime;
        tank.fillAmount = fuel;
        ProgressBar();
       
    }
    void Move() 
    {
     //   ProgressBar();
        if (fuel > 0) 
        {
            if (GAs) 
            {
               
                WheelR.AddForce(Vector2.right * Time.deltaTime * Speed);
                WheelR.AddTorque(-_Torque);
                Body.AddTorque(_Torque);
            }
            if (BReak) 
            {
                /*fuel -= fuelconsumption * Time.fixedDeltaTime;
                tank.fillAmount = fuel;*/
                WheelR.AddForce(Vector2.left * Time.deltaTime * Speed*2);
                WheelR.AddTorque(_Torque);
                Body.AddTorque(-_Torque);
            }     
        }
       //score;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fuel") 
        {
            print("Ht");
            fuel= 1;
            //FuelTank..SetActive(false);
            collision.gameObject.SetActive(false);
            
        }
        if (collision.gameObject.tag == "Coin25")
        {
            score += 25;
            print("Score is 25");
            collision.gameObject.SetActive(false);

        }
        if (collision.gameObject.tag == "Coin5")
        {
            score += 5;
            print("Score is 5");
            collision.gameObject.SetActive(false);

        }
        if (collision.gameObject.tag == "Coin100")
        {
            score += 100;
            print("Score is 100");
            collision.gameObject.SetActive(false);

        }
        if (collision.gameObject.tag == "Coin500")
        {
            score += 500;
            print("Score is 500");
            collision.gameObject.SetActive(false);

        }
        if (collision.gameObject.tag == "Spawn") 
        {
            Spawn.btn();
            print(" on Roll");
            
        }


    }
    public void BreakDown()
    {
        BReak = true;
        I_Break.transform.Rotate( new Vector3(30, 0, 0));
    }
    public void BreakUp() 
    {
        BReak = false;
        I_Break.transform.Rotate( new Vector3(-30, 0, 0));
    }
    public void GasDown() 
    {
        GAs = true;
        I_Gas.transform.Rotate(new Vector3(30, 0, 0));
    }
    public void GasUp() 
    {
        GAs = false;
        I_Gas.transform.Rotate(new Vector3(-30, 0, 0));
    }
    void ProgressBar()
    {
        Progress.fillAmount = 0;
        CarX = transform.position.x;
        //  Mathf.Abs(CarX)/Mathf.Abs(200);
        float Sol = ((CarX /  500) - IncrI);
       // Debug.LogWarning(Sol);
        Progress.fillAmount = Sol;
        if (Sol > 1) 
        {
            Progress.fillAmount = 0;  
            IncrI += 1;
            Lev += 1;
            Debug.LogError(Sol);
        }
    }
}
