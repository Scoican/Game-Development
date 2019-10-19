using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public GameObject buildingEffect;
    public GameObject sellEffect;
    private TurretBlueprint turretToBuild;
    //Singleton pattern
    public static BuildManager instance;
    private NodeScript selectedNode;
    public TurretUIScript turretUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money>=turretToBuild.cost; } }

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene!");
        }
        instance = this;
    }

    public void SelectNode(NodeScript node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        this.selectedNode = node;
        this.turretToBuild = null;

        turretUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        turretUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        this.turretToBuild = turretBlueprint;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return this.turretToBuild;
    }

}
