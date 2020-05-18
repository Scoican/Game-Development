using UnityEngine;

public class BallMovement : MonoBehaviour
{

	// Movement speed
	public float speed = 100f;
	public GameObject uiStartGameText;

	// Use this for initialization
	void Start()
	{
		if (GameManager.instance.hasGameStarted == true)
		{
			GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
		}
	}

	private void Update()
	{
		if (transform.position.y < -120)
		{
			Destroy(gameObject);
			GameManager.instance.DecrementNumberOfBalls();
		}
		if (Input.GetKeyDown(KeyCode.Space) && !GameManager.instance.hasGameStarted)
		{
			GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
			GameManager.instance.hasGameStarted = true;
			uiStartGameText.SetActive(false);
		}
		if (GameManager.instance.isGameFinished)
		{
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		// This function is called whenever the ball
		// collides with something

		// Hit the Racket?
		if (col.gameObject.tag == "Player")
		{
			//Calculate hit factor
			float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

			//Calculate direction, set length to 1
			Vector2 direction = new Vector2(x, 1).normalized;

			//Set velocity to direction*speed
			GetComponent<Rigidbody2D>().velocity = direction * speed;
		}
	}

	private float hitFactor(Vector2 ballPosisition, Vector2 racketPosition, float racketWidth)
	{
		// ascii art:
		//
		// 1  -0.5  0  0.5   1  <- x value
		// ===================  <- racket
		//
		return (ballPosisition.x - racketPosition.x) / racketWidth;
	}
}
