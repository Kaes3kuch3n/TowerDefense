using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color denyBuildColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    [HideInInspector]
    public GameObject turretPreview;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;

        if (turret != null)
        {
            turret = Instantiate(turret, GetBuildPosition(), Quaternion.identity);
        }
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.price)
        {
            Debug.Log("You don't have enough money to build that!");
            return;
        }

        PlayerStats.money -= blueprint.price;

        turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradePrice)
        {
            Debug.Log("You don't have enough money to upgrade that!");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradePrice;

        //Destroy old turret
        Destroy(turret);
        //Build new turret
        turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);

        GameObject effect = (GameObject)Instantiate(buildManager.upgradeEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.GetSellPrice();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
        }
        
        if (!buildManager.CanBuild) return;

        //Destroy preview
        if (turretPreview != null)
        {
            Destroy(turretPreview);
            buildManager.HideRadiusVisualizer();
        }

        turretBlueprint = buildManager.GetTurretToBuild();
        BuildTurret(turretBlueprint);
        buildManager.SelectTurretToBuild(null);
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (turret != null)
        {
            rend.material.color = hoverColor;
        }

        if (!buildManager.CanBuild) return;

        if (buildManager.HasMoney && turret == null)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = denyBuildColor;
        }

        if (turret == null)
        {
            buildManager.ShowTurretPreview(this);
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
        if (turretPreview != null)
        {
            Destroy(turretPreview);
        }
    }
}
