// MARIANO CODUTTI ALARCON
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int startMoney = 100;
    public static int money;

    [SerializeField] private int startHealth = 20;
    public static int playerHealth;

    public static int waves;

    // Score values
    public static int score_KillPoints;
    public static int score_WavesCalled;
    public static int score_Invested;


    private void Start()
    {
        money = startMoney;
        playerHealth = startHealth;
        waves = 0;

        score_KillPoints = 0;
        score_WavesCalled = 0;
        score_Invested = 0;
    }


    public int GetStartHealth()
    {
        return startHealth;
    }
}
