using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text endGameText;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Ball")
        {
            endGameText.enabled = true;
            Time.timeScale = 0;
        }
    }
}
