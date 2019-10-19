using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    // Movement speed
    public float speed = 100f;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // This function is called whenever the ball
        // collides with something

        // Hit the Racket?
        if (col.gameObject.name == "Vaus")
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
