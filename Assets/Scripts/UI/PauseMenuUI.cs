// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;

    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private string mainMenuScene = "MenuScene";


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }


    public void TogglePause()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);

        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void RestartGame()
    {
        TogglePause();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        TogglePause();
        sceneFader.FadeTo(mainMenuScene);
    }
}
