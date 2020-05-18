using UnityEngine;

public class Block : MonoBehaviour
{
	public GameObject PowerUpPrefab;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("PowerUps"))
		{
			return;
		}
		if (Random.Range(0f, 1f) >= 0.75f)
		{
			DropPowerUp();
		}
		GameManager.instance.DecrementNumberOfBricks();
		Destroy(gameObject);
	}

	private void DropPowerUp()
	{
		Instantiate(PowerUpPrefab, transform.position, Quaternion.identity);
	}
}
