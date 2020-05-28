using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public GameObject startTurret;
    public Color hoverTrueColor;
    public Color hoverFalseColor;
    private Renderer rend;
    private Color startColor;
    public GameObject turret;
    public Vector3 positionOffSet;
    BuildManager buildManager;
    void Start ()
    {
        startTurret = null;
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
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;

        }
        buildManager.BuildTurretOn(this);
        rend.material.color = hoverFalseColor;
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
        if (turret==null)
        {
            rend.material.color = hoverTrueColor;
        }
        if (turret!=null)
        {
            rend.material.color = hoverFalseColor;
        }

    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    public void afterPurchase()
    {
        turret = startTurret;
    }
}
