// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    [SerializeField] private GameObject nodeUI;
    private Node nodeTarget;

    [SerializeField] private TMP_Text upgradeCostText;
    [SerializeField] private TMP_Text sellAmountText;

    [SerializeField] private Button upgradeButton;


    public void SetTarget(Node _target)
    {
        nodeTarget = _target;

        transform.position = nodeTarget.GetBuildPosition();

        if (!nodeTarget.isUpgraded)
        {
            upgradeCostText.text = "$" + nodeTarget.towerBlueprint.upgradeCost;

            if (!nodeTarget.isUpgraded)
            {
                if (PlayerStats.money < nodeTarget.towerBlueprint.upgradeCost)
                {
                    upgradeButton.interactable = false;
                }
                else
                {
                    upgradeButton.interactable = true;
                }
            }
        }
        else
        {
            upgradeCostText.text = "MAX";
            upgradeButton.interactable = false;
        }

        if (nodeTarget.isUpgraded)
        {
            sellAmountText.text = "$" + nodeTarget.towerBlueprint.GetUpgradedSellAmount();
        }
        else
        {
            sellAmountText.text = "$" + nodeTarget.towerBlueprint.GetSellAmount();
        }
        
        nodeUI.SetActive(true);
    }

    public void HideNodeUI()
    {
        nodeUI.SetActive(false);
    }

    public void Upgrade()
    {
        nodeTarget.UpgradeTower();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        nodeTarget.SellTower();
        BuildManager.instance.DeselectNode();
    }
}
