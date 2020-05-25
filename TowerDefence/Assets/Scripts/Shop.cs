
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseMachineTurret ()
    {
        Debug.Log("Machine Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.machineTurretPrefab);
    }
    public void PurchaseMissileTurret()
    {
        Debug.Log("Missile Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.missileTurretPrefab);
    }

}
