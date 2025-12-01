// MARIANO CODUTTI ALARCON
using UnityEngine;

public class Node : MonoBehaviour
{
    private BuildManager buildManager;

    [SerializeField] private Vector3 towerPositionOffset;

    [SerializeField] private GameObject nodeAvailableHighlight;
    [SerializeField] private GameObject nodeNotEnoughMoneyHighlight;

    [SerializeField] private GameObject BuildEffect;
    [SerializeField] private GameObject SellEffect;

    [HideInInspector] public GameObject tower;
    [HideInInspector] public TowerBlueprint towerBlueprint;
    [HideInInspector] public bool isUpgraded;


    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            nodeAvailableHighlight.SetActive(true);
        }
        else
        {
            nodeNotEnoughMoneyHighlight.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        nodeAvailableHighlight.SetActive(false);
        nodeNotEnoughMoneyHighlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (tower != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTower(buildManager.GetTowerToBuild());
    }


    private void BuildTower(TowerBlueprint _blueprint)
    {
        if (PlayerStats.money < _blueprint.cost)
        {
            // Debug.Log("NOT ENOUGH MONEY TO BUILD THAT");
            return;
        }

        PlayerStats.money -= _blueprint.cost;
        PlayerStats.score_Invested += _blueprint.cost;

        GameObject towerGO = (GameObject)Instantiate(_blueprint.towerPrefab, GetBuildPosition(), Quaternion.identity);
        tower = towerGO;

        towerBlueprint = _blueprint;

        GameObject buildEffectGO = (GameObject)Instantiate(BuildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffectGO, 2f);

        // Debug.Log("TOWER BUILT! MONEY LEFT:" + PlayerStats.money);
    }

    public void UpgradeTower()
    {
        if (PlayerStats.money < towerBlueprint.upgradeCost)
        {
            // Debug.Log("NOT ENOUGH MONEY TO UPGRADE THAT");
            return;
        }

        PlayerStats.money -= towerBlueprint.upgradeCost;
        PlayerStats.score_Invested += towerBlueprint.upgradeCost;

        // Destroy previous tower.
        Destroy(tower);

        // Build new tower.
        GameObject towerGO = (GameObject)Instantiate(towerBlueprint.towerUpgradePrefab, GetBuildPosition(), Quaternion.identity);
        tower = towerGO;

        GameObject upgradeEffectGO = (GameObject)Instantiate(BuildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(upgradeEffectGO, 2f);

        isUpgraded = true;

        // Debug.Log("TOWER UPGRADED");
    }

    public void SellTower()
    {
        if (isUpgraded)
        {
            PlayerStats.money += towerBlueprint.GetUpgradedSellAmount();
        }
        else
        {
            PlayerStats.money += towerBlueprint.GetSellAmount();
        }

        GameObject sellEffectGO = (GameObject)Instantiate(SellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(sellEffectGO, 2f);

        Destroy(tower);
        towerBlueprint = null;
        isUpgraded = false;
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + towerPositionOffset;
    }
}
