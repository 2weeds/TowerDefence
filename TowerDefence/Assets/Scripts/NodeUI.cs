﻿using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node target;

  


    public GameObject ui;
   
   

    public void SetTarget(Node _target)
    {
        this.target = _target;

        transform.position = target.GetBuildPosition();
       
      
        
        ui.SetActive(true);

       
    }

    public void Hide ()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell ()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
 
}
