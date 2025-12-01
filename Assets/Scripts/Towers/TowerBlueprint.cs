// MARIANO CODUTTI ALARCON
using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
    public GameObject towerPrefab;
    public int cost;

    public GameObject towerUpgradePrefab;
    public int upgradeCost;


    public int GetSellAmount()
    {
        return cost / 2;
    }

    public int GetUpgradedSellAmount()
    {
        return upgradeCost / 2;
    }
}
