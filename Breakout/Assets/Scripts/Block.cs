using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public float chance = 25f;

    public Transform buff;

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        DropBuff();
    }

    private void DropBuff()
    {
        float r = Random.Range(1, 100);
        if (r <= chance)
        {
            Instantiate(buff, transform.position, transform.rotation);
        }
    }
}
