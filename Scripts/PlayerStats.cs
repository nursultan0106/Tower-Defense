using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Lives;
    public static int Rounds;
    public static int Money;
    public int startLives = 20;
    public int startMoney = 400;
    private void Start()
    {
        Rounds = 0;
        Money = startMoney;
        Lives = startLives;
    }
}