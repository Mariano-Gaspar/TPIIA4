// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text wavesAmountText;

    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private string mainMenuScene = "MenuScene";


    private void OnEnable()
    {
        wavesAmountText.text = PlayerStats.waves.ToString();
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
