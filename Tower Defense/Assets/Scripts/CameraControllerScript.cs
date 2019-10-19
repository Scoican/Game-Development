using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour {

    private bool doMovement = false;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float rotationSpeed = 1.5f;
    public float minY = 10f;
    public float maxY = 80f;

	
	// Update is called once per frame
	void Update () {

        if (GameManagerScript.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown("v"))
        {
            doMovement = !doMovement;
        }
        if (!doMovement)
        {
            return;
        }
        //Camera position movement
        //if (Input.GetKey("w") || Input.mousePosition.y>=Screen.height - panBorderThickness)
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward*panSpeed*Time.deltaTime,Space.World);
        }
        //if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        //if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        //if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        //Camera zoom

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = transform.position;
        position.y -= scroll * 500 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;

    }
}
