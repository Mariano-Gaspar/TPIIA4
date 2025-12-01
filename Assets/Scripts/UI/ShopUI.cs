// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private TowerBlueprint towerBallista;
    [SerializeField] private TowerBlueprint towerCannon;
    [SerializeField] private TowerBlueprint towerCatapult;

    [SerializeField] private Button ballistaButton;
    [SerializeField] private Image ballistaIcon;
    [SerializeField] private Button canonButton;
    [SerializeField] private Image canonIcon;
    [SerializeField] private Button catapultButton;
    [SerializeField] private Image catapultIcon;

    [SerializeField] private Color availableColor = Color.white;
    [SerializeField] private Color notAvailableColor = Color.black;

    private BuildManager buildManager;


    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void Update()
    {
        CheckButtons();
    }


    private void CheckButtons()
    {
        if (PlayerStats.money < towerBallista.cost)
        {
            ballistaButton.interactable = false;
            ballistaIcon.color = notAvailableColor;
        }
        else
        {
            ballistaButton.interactable = true;
            ballistaIcon.color = availableColor;
        }

        if (PlayerStats.money < towerCannon.cost)
        {
            canonButton.interactable = false;
            canonIcon.color = notAvailableColor;
        }
        else
        {
            canonButton.interactable = true;
            canonIcon.color = availableColor;
        }

        if (PlayerStats.money < towerCatapult.cost)
        {
            catapultButton.interactable = false;
            catapultIcon.color = notAvailableColor;
        }
        else
        {
            catapultButton.interactable = true;
            catapultIcon.color = availableColor;
        }
    }


    public void SelectTowerBallista()
    {
        // Debug.Log("Ballista selected");
        buildManager.SelectTowerToBuild(towerBallista);
    }

    public void SelectTowerCannon()
    {
        // Debug.Log("Cannon selected");
        buildManager.SelectTowerToBuild(towerCannon);
    }

    public void SelectTowerCatapult()
    {
        // Debug.Log("Cannon selected");
        buildManager.SelectTowerToBuild(towerCatapult);
    }
}
