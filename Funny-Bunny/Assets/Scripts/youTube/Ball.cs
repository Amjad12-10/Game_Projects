
using UnityEngine;

public class Ball : MonoBehaviour
{
	[HideInInspector] public Rigidbody2D rb;
	[HideInInspector] public Collider2D col;
	[HideInInspector] public Vector3 pos { get { return transform.position; } }

	GameManager Manager;
	public bool Merge = false;

	BallCollision Col;

	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<Collider2D> ();
		Manager = FindObjectOfType<GameManager>();
	}
    private void Start()
    {
		Col = GetComponent<BallCollision>();
		DesactivateRb();
	}
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
		{
			Col.EmojiHandler[2].gameObject.SetActive(true);
			Manager.isDragging = true;
			Manager.OnDragStart();
		}
        if (Input.GetMouseButtonUp(0))
        {
			Col.EmojiHandler[3].gameObject.SetActive(true);
			Manager.OnDragEnd();
		}
    }
    public void Push (Vector2 force)
	{
		rb.AddForce (force, ForceMode2D.Impulse);
	}

	public void ActivateRb ()
	{
		rb.isKinematic = false;
	}

	public void DesactivateRb ()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity =0;
		rb.isKinematic = true;

	}

}
