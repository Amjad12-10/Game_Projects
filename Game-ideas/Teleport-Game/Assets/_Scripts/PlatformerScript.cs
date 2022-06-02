using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class PlatformerScript : MonoBehaviour
{
    private Gun Player;
    Rigidbody2D rb;
    [Space]
    public bool Direction;
    [Space]
    [Header("Player")]
    public float jumpForce;
    public float speed;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    
    bool isGrounded = false;
    [Space]
    [Header("Check")]
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    [Header("Sound")]
    private AudioSource _Jump;
    private UIManager UI;

    private bool inControl = true;

    // Start is called before the first frame update
    private void Awake()
    {
        UI = FindObjectOfType<UIManager>();
    }

    void Start()
    {

        Player = FindObjectOfType<Gun>();
        rb = Player.GetComponent<Rigidbody2D>();
        _Jump = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inControl){
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
        }
    }
    void Move()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) 
        {
          
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
           
            this.gameObject.transform.localScale = new Vector3(-(1), 1, 1);
        }

        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)  && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            _Jump.Play();
        }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            _Jump.Play();
        }
       
    }
  
    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Queen") 
        {
            UI.OnWin();
            collision.gameObject.SetActive(false);
            inControl = false;
            StartCoroutine(PlayerWin());
            
        }
        if (collision.gameObject.tag == "Respawn")
        {
            Debug.Log("Restart");
            collision.GetComponent<AudioSource>().Play();
            Invoke("Restart", 1.5f);
        }
    }
    void Restart() 
    {
        SceneManager.LoadScene(0);
    }
   
   IEnumerator PlayerWin(){
       yield return new WaitForSeconds(5);
       this.transform.DOMoveX(15,2,false);
   }

}
