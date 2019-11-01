using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDuplication : MonoBehaviour
{
    public Transform ball;

    public void DuplicateBall()
    {
        Instantiate(ball, ball.position, ball.rotation);
    }
}
