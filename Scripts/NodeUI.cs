using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public Text sellCost;
    public Text upgradeCost;
    public Button upgradeButton;
    public void SetTarget(Node n)
    {
        target = n;
        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        sellCost.text = "$" + target.turretBlueprint.GetSellCost().ToString();
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}