using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour {

	//Movement speed
	public float speed = 150f;

	void FixedUpdate() {
		//Get horizontal input
		float horizontal= Input.GetAxisRaw("Horizontal");

		//Set velocity
		GetComponent<Rigidbody2D>().velocity = Vector2.right * horizontal * speed;
	}
}
