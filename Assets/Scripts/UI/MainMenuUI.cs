// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private Button continueButton;

    [SerializeField] private SceneFader sceneFader;


    public void PlayGame()
    {
        sceneFader.FadeTo(sceneToLoad);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteKey("levelReached");
        PlayerPrefs.Save();

        PlayGame();
    }

    public void QuitGame()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }

    public void ShowCredits()
    {
        creditsMenu.SetActive(true);
    }

    public void HideCredits()
    {
        creditsMenu.SetActive(false);
    }
}
