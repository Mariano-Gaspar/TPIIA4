// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameWonUI : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyLeftText;
    [SerializeField] private TMP_Text killPointsText;
    [SerializeField] private TMP_Text wavesCalledText;
    [SerializeField] private TMP_Text investedText;
    [SerializeField] private TMP_Text livesMultiplierText;
    [SerializeField] private TMP_Text totalScoreText;

    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private string mainMenuScene = "MenuScene";


    private void OnEnable()
    {
        moneyLeftText.text = "Money left: +" + PlayerStats.money + "pts";
        killPointsText.text = "Kill points: +" + PlayerStats.score_KillPoints + "pts";
        wavesCalledText.text = "Waves called: +" + PlayerStats.score_WavesCalled + "pts";

        investedText.text = "Invested: -" + PlayerStats.score_Invested + "pts";
        livesMultiplierText.text = "Lives multiplier: x" + ((float)PlayerStats.playerHealth / 10f).ToString("0.0");

        totalScoreText.text = GameManager.totalScore.ToString();
    }


    public void RestartGame()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void GoToMenu()
    {
        sceneFader.FadeTo(mainMenuScene);
        Time.timeScale = 1f;
    }
}
