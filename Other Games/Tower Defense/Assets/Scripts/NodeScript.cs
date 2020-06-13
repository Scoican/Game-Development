using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeScript : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;


    private Renderer rend;
    BuildManager buildManager;

    void Start()
    { 
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }     

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        this.BuildTurret(buildManager.GetTurretToBuild());
    }

	void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build turret!");
            return;
        }
        PlayerStats.Money = PlayerStats.Money - blueprint.cost;

        GameObject turret = (GameObject)Instantiate(blueprint.prefab, this.GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildingEffect, this.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade turret!");
            return;
        }
        PlayerStats.Money = PlayerStats.Money - turretBlueprint.upgradeCost;

        Destroy(this.turret);

        GameObject turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, this.GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildingEffect, this.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellCost();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, this.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(this.turret);
        turretBlueprint = null;
    }
}
