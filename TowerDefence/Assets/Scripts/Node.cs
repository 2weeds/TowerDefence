using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverTrueColor;
    public Color hoverFalseColor;
    private Color startColor;
    private Renderer rend;
    public GameObject turret;
    public Vector3 positionOffSet;
    BuildManager buildManager;
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
        rend.material.color = startColor;
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
