using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject ui;
    public Button upgradeButton;
    public Text upgradePrice;
    public Text sellPrice;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        //Set upgrade price text
        if (!target.isUpgraded && target.turretBlueprint.hasUpgrade)
        {
            upgradePrice.text = "$ " + target.turretBlueprint.upgradePrice.ToString();
            upgradeButton.interactable = true;
        } else if (!target.turretBlueprint.hasUpgrade)
        {
            upgradePrice.text = "──";
            upgradeButton.interactable = false;
        } else
        {
            upgradePrice.text = "MAX";
            upgradeButton.interactable = false;
        }

        //Set sell price text
        sellPrice.text = "$ " + target.turretBlueprint.GetSellPrice().ToString();

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
