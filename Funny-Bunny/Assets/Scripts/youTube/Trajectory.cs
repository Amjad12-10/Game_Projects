
using UnityEngine;

public class Trajectory : MonoBehaviour
{
	[Header("Dots")]
	[SerializeField] int dotsNumber;
	[SerializeField] GameObject dotsParent;
	[SerializeField] GameObject dotPrefab;
	[Header("Variables")]
	[SerializeField] float dotSpacing;

	Transform[] dotsList;

	Vector2 pos;
	float timeStamp;

	//--------------------------------
	void Start ()
	{
		//hide trajectory in the start
		Hide ();
		//prepare dots
		PrepareDots ();
	}

	void PrepareDots ()
	{
		dotsList = new Transform[dotsNumber];

		for (int i = 0; i < dotsNumber; i++) {
			dotsList [i] = Instantiate (dotPrefab, null).transform;
			dotsList [i].parent = dotsParent.transform;
		}
	}

	public void UpdateDots (Vector2 ballPos, Vector2 forceApplied)
	{
		timeStamp = dotSpacing;
		for (int i = 0; i < dotsNumber; i++) {
				pos = (ballPos + forceApplied * timeStamp) -((-Physics2D.gravity* timeStamp * timeStamp) /2f);
			dotsList [i].position = pos;
			timeStamp += dotSpacing;
		}
	}

	public void Show ()
	{
		dotsParent.SetActive (true);
	}

	public void Hide ()
	{
		dotsParent.SetActive (false);
	}
}
