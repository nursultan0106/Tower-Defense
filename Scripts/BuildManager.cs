using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject buildEffect;
    public GameObject sellEffect;
    public NodeUI nodeUI;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Build Manager!");
            return;
        }
        instance = this;
    }
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }
    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
        DeselectNode();
    }
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    } 
}