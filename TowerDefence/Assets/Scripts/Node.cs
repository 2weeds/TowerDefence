using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverTrueColor;
    public Color hoverFalseColor;
    private Color startColor;
    private Renderer rend;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    public Vector3 positionOffSet;
    BuildManager buildManager;

    public TurretBlueprint turretToBuild;

    void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }
    private void OnMouseDown()
    {
        
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //if (!buildManager.CanBuild)
        //{
        //    return;
        //}
        if (turret != null)
        {
            buildManager.SelectNode(this);
            //Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());
        rend.material.color = startColor;
    }

    void BuildTurret (TurretBlueprint blueprint)
    {
        if(PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        
        
        buildManager.SelectTurretToBuild(null);
    }
    public void UpgradeTurret ()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;
        //panaikina sena
        Destroy(turret);

        //darom nauja

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        

        isUpgraded = true;
    }

    public void TokenTurretUpgrade() 
    {
        if (PlayerStats.Token < turretBlueprint.tokenUpgradeCost)
        {
            Debug.Log("Not enough tokens to upgrade that!");
            return;
        }
        PlayerStats.Token -= turretBlueprint.tokenUpgradeCost;
        Destroy(turret);

        //darom nauja

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.TokenUpgradePrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
    }
    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmont();
        Destroy(turret);
        turretBlueprint = null;

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

        if (turret != null)
        {
            rend.material.color = hoverFalseColor;
        }
        if (turret == null)
        {
            rend.material.color = hoverTrueColor;
        }
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
