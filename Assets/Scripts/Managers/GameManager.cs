// MARIANO CODUTTI ALARCON
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject levelCompleteUI;

    [SerializeField] private int levelToUnlock = 2;

    public static bool gameIsOver;
    public static int totalScore;


    private void Start()
    {
        gameIsOver = false;
        totalScore = 0;
    }

    private void Update()
    {
        if (gameIsOver)
            return;

        if (PlayerStats.playerHealth <= 0)
        {
            EndGame();
        }
    }


    private void EndGame()
    {
        gameIsOver = true;
        Time.timeScale = .25f;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        int currentLevelReached = PlayerPrefs.GetInt("levelReached", 1);

        PlayerPrefs.SetInt("levelReached", Mathf.Max(currentLevelReached, levelToUnlock));
        PlayerPrefs.Save();

        // Calculate final points
        totalScore = (int)(((PlayerStats.money + PlayerStats.score_KillPoints + PlayerStats.score_WavesCalled) - PlayerStats.score_Invested) * ((float)PlayerStats.playerHealth / 10f));

        if (totalScore < 0) totalScore = 0;

        gameIsOver = true;
        Time.timeScale = .25f;
        levelCompleteUI.SetActive(true);
    }
}
