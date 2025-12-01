// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorUI : MonoBehaviour
{
    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private string mainMenuScene = "MenuScene";

    [SerializeField] private Button[] levelButtons;


    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = i + 1 <= levelReached;
        }
    }


    public void SelectLevel(string _levelName)
    {
        sceneFader.FadeTo(_levelName);
    }

    public void GoBack()
    {
        sceneFader.FadeTo(mainMenuScene);
    }
}
