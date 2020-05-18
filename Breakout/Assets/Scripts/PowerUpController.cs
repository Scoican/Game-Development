using UnityEngine;

public class PowerUpController : MonoBehaviour
{
	public float fallSpeed = 100.0f;
	public GameObject BallPrefab;

    // Update is called once per frame
    void Update()
    {
		if (transform.position.y < -125)
		{
			Destroy(gameObject);
		}
		if (GameManager.instance.isGameFinished)
		{
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}
	}

	private void Start()
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.down * fallSpeed;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "Player")
		{
			var spawnPosition = new Vector2(other.transform.position.x, -80);
			Instantiate(BallPrefab, spawnPosition, Quaternion.identity);
			GameManager.instance.NumberOfBalls++;
			Destroy(gameObject);
		}
	}
}
