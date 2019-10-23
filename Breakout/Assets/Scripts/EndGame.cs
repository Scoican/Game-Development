using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameMaster master;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball" && !col.gameObject.name.Contains("Clone"))
        {
            master.EndGame();
        }
        else
        {
            Destroy(col.gameObject);
        }
    }
}
