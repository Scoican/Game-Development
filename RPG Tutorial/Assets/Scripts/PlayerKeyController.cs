using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyController : MonoBehaviour {

    public float MovementSpeed = 5.0f;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        {
            GetComponent<PlayerClickController>().enabled = true;
            this.enabled = false;
        }

        transform.Translate(-Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed, 0, 0);
        transform.Translate(0, 0, -Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed);
    }
}
