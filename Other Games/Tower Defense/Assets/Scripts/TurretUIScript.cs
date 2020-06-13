using UnityEngine;
using UnityEngine.UI;

public class TurretUIScript : MonoBehaviour {

    private NodeScript target;
    public GameObject canvasUI;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellCost;

    public void SetTarget(NodeScript node)
    {
        this.target = node;
        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.cost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "UNAVAILABLE";
            upgradeButton.interactable = false;
        }
        sellCost.text = "$" + target.turretBlueprint.GetSellCost();
        canvasUI.SetActive(true);
    }

    public void Hide()
    {
        canvasUI.SetActive(false);
    }

    public void Upgrade()
    {
        if (target.isUpgraded)
        {
            return;
        }
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
