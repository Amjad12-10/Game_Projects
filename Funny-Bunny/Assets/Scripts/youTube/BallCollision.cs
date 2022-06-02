using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class BallCollision : MonoBehaviour
{
	public Transform[] EmojiHandler;
	Rigidbody2D rb;

	Ball ball;

	// Start is called before the first frame update
	void Start()
    {
		
		rb = GetComponent<Rigidbody2D>();
		this.transform.DOPunchScale(new Vector3(0.005f, 0.005f, 0.005f), 0.25f, 10, 1).SetLoops(-1);
		ball = GetComponent<Ball>();
		EmojiHandler = this.gameObject.GetComponentsInChildren<Transform>();
		for (int i = 2; i < EmojiHandler.Length; i++)
		{
			EmojiHandler[i].gameObject.SetActive(false);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Finish"))
		{
			EmojiHandler[4].gameObject.SetActive(true);
			rb.bodyType = RigidbodyType2D.Static;
			collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
			ball.Merge = true;
			StartCoroutine(Started());
		}
		if (collision.gameObject.CompareTag("Respawn"))
		{
			collision.gameObject.SetActive(false);
			EmojiHandler[5].gameObject.SetActive(true);

		}
	}
	IEnumerator Started()
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(1);
	}
}
