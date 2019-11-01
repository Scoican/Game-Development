using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateBuff : MonoBehaviour
{

    public float speed = 25f;

    public Transform ballPrefab;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Vaus")
        {
            Destroy(gameObject);
            ballPrefab.GetComponent<BallDuplication>().DuplicateBall();
        }
        if (other.gameObject.tag == "Ball")
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }

}
