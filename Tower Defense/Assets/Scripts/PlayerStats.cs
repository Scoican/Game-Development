using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startingMoney = 400;

    public static int Lives;
    public int startingLives = 20;

    public static int Rounds;

    private void Start()
    {
        Money = startingMoney;
        Lives = startingLives;
        Rounds = 0;
    }
}