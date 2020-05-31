using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;

    }
    public GameObject machineTurretPrefab;

    public GameObject missileLauncherPrefab;
    public GameObject missleTurretPrefab;



    public TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;
    public bool CanBuild { get { return turretToBuild != null; } }
    public void BuildTurretOn(Node node)
    {
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        PlayerStats.Money -= turretToBuild.cost;
        SelectTurretToBuild(null);
    }

    public void SelectNode (Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode ()
    {
        selectedNode = null;
        nodeUI.Hide();

    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
}
