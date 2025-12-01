// MARIANO CODUTTI ALARCON
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] private NodeUI nodeUI;

    private TowerBlueprint towerToBuild;
    private Node selectedNode;


    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }


    public void SelectNode(Node _node)
    {
        if (selectedNode == _node)
        {
            DeselectNode();
            return;
        }

        selectedNode = _node;
        towerToBuild = null;
        nodeUI.SetTarget(_node);
    }

    public void DeselectNode()
    {
        selectedNode = null;

        nodeUI.HideNodeUI();
    }

    public void SelectTowerToBuild(TowerBlueprint _tower)
    {
        towerToBuild = _tower;

        DeselectNode();
    }


    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }

    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= towerToBuild.cost; } }
}
