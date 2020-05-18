using System.Collections.Generic;
using UnityEngine;

public class MultiplayerRacketMovement : MonoBehaviour
{
	public float speed = 150f;
	List<GameObject> players = new List<GameObject>();

	void FixedUpdate()
	{
		if (!GameManager.instance.isGameFinished)
		{

			foreach (GameObject player in GameObject.FindObjectsOfType(typeof(GameObject)))
			{
				if (player.tag == "Player" && !players.Contains(player))
					players.Add(player);
			}

			if(players[0].transform.position.x > -87 && players[0].transform.position.x < 87)
			{
				if (Input.GetKey(KeyCode.A))
					players[0].transform.Translate(Vector3.left * speed * Time.deltaTime);
				if (Input.GetKey(KeyCode.D))
					players[0].transform.Translate(Vector3.right * speed * Time.deltaTime);
			}
			else
			{
				if(players[0].transform.position.x <= -87)
				{
					if (Input.GetKey(KeyCode.D))
						players[0].transform.Translate(Vector3.right * speed * Time.deltaTime);
				}
				if (players[0].transform.position.x >= 87)
				{
					if (Input.GetKey(KeyCode.A))
						players[0].transform.Translate(Vector3.left * speed * Time.deltaTime);
				}
			}

			if(players[1].transform.position.x > -87 && players[1].transform.position.x < 87)
			{
				if (Input.GetKey(KeyCode.LeftArrow))
					players[1].transform.Translate(Vector3.left * speed * Time.deltaTime);
				if (Input.GetKey(KeyCode.RightArrow))
					players[1].transform.Translate(Vector3.right * speed * Time.deltaTime);
			}
			else
			{
				if(players[1].transform.position.x <= -87)
				{
					if (Input.GetKey(KeyCode.RightArrow))
						players[1].transform.Translate(Vector3.right * speed * Time.deltaTime);
				}
				if (players[1].transform.position.x >= 87)
				{
					if (Input.GetKey(KeyCode.LeftArrow))
						players[1].transform.Translate(Vector3.left * speed * Time.deltaTime);
				}
			}
		}
	}
}
