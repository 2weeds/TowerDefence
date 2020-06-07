using UnityEngine;
using Unity;

public class Shop : MonoBehaviour
{
    
    BuildManager buildManager;
    public TurretBlueprint missileTurret;
    public TurretBlueprint machineTurret;
    public TurretBlueprint missleLauncher;
    public TurretBlueprint minigunTurret;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    
    public void SelectMachineTurret ()
    {
        Debug.Log("Machine Turret Purchased");
        buildManager.SelectTurretToBuild(machineTurret);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Turret Purchased");
        buildManager.SelectTurretToBuild(missleLauncher);
    }
    public void SelectMissileTurret()
    {
        buildManager.SelectTurretToBuild(missileTurret);
    }
    public void SelectMinigunTurret() 
    {
        buildManager.SelectTurretToBuild(minigunTurret);
    }
}
