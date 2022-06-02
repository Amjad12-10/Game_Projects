
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
	#region Singleton class: GameManager

	public static GameManager Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
		}
	}

	#endregion

	Camera cam;
	Trajectory trajectory;
	LineRenderer Renderer;
	[SerializeField]Ball ball;

	[Header("BallComponents")]
	public GameObject BallPrefab;
	public Transform BallParent;

	public Transform[] BunnyEmojiHandler;

	public GameObject Win;
 
	public Transform BunnyParent;

	[HideInInspector] public bool isDragging = false;


	Vector3 startPoint;
	Vector3 endPoint;
	Vector3 direction;
	Vector2 force;

	float distance;
	public float pushForce;

	public GameObject Love;

	//---------------------------------------
	void Start ()
	{

		trajectory = FindObjectOfType<Trajectory>();
		ball = FindObjectOfType<Ball>();

		BunnyEmojiHandler = BunnyParent.gameObject.GetComponentsInChildren<Transform>();

		cam = Camera.main;
		ball.DesactivateRb ();

		Renderer = ball.GetComponent<LineRenderer>();
	}

	void Update ()
	{
        if (ball.Merge) 
		{
			Win.SetActive(true);
			Love.SetActive(true);
			BunnyEmojiHandler[1].gameObject.GetComponent<SpriteRenderer>().enabled = false;
			for (int i =1; i< BunnyEmojiHandler.Length; i++)
            {
                if (i != 4 && i != 1 ) 
				{
					BunnyEmojiHandler[i].gameObject.SetActive(false);
				}
            }
		}
		if (isDragging && Input.GetMouseButton(0))
		{
			OnDrag();
		}
		else
		{

			//float angle = Mathf.Atan2(ball.rb.velocity.y, ball.rb.velocity.x) * Mathf.Rad2Deg;
			//ball.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

	//-Drag--------------------------------------
	public void OnDragStart ()
	{
			ball = FindObjectOfType<Ball>();
			ball.DesactivateRb();
			startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
			Renderer.enabled = true;
			trajectory.Show();
	}

	void OnDrag ()
	{
			endPoint = cam.ScreenToWorldPoint(Input.mousePosition);

			// force
			distance = Vector3.Distance(startPoint, endPoint);

			direction = (startPoint - endPoint).normalized;
			force = direction * distance * pushForce;

			// Object Transform

			ball.transform.rotation = Quaternion.EulerAngles(0, 0, -direction.x);
			ball.transform.position = Vector3.ClampMagnitude(endPoint, 1.5f);
			Renderer.SetPosition(1, ball.transform.position);

			// Update Dots
			trajectory.UpdateDots(ball.pos, force);
	
	}

	public void OnDragEnd ()
	{
		
		{
			isDragging = false;

			//push the ball
			ball.ActivateRb();
			ball.Push(force);
			Renderer.enabled = false;
			trajectory.Hide();
			StartCoroutine(Wake());

			ball.enabled = false;
		}

	}
	
	IEnumerator Wake() 
	{
		
		yield return new WaitForSeconds(1.5f);
		Instantiate(BallPrefab, BallParent);

	}

}
