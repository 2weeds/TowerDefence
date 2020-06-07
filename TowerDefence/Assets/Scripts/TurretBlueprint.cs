using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity;

[System.Serializable]
public class TurretBlueprint { 
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;

    public GameObject TokenUpgradePrefab;

    public int upgradeCost;
    public int tokenUpgradeCost;

    public int GetSellAmont()
    {
        return cost / 2;
    }
     
}