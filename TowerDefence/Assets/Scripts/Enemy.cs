using System.Collections;
using UnityEngine.UI;

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public int worth = 50;
    [HideInInspector]
    private Transform target;
    private int wavepointIndex = 0;
    public float startHealth = 100;
    private float health;
    
    [Header("Unity Stuff")]
    public Image healthBar;
    void Start()
    {
        health = startHealth;
        target = Waypoint.points[0];
    }
    void Update()
    {
        if (target!=null)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * startSpeed * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, target.position) <= 0.2)
            {
                
                GetNextWayPoint();
                transform.Rotate(dir);
            }
            
        } 
    }
    void GetNextWayPoint()
    {
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            Destroy(gameObject);
            wavepointIndex = -1;
        }
        else
        {
            wavepointIndex++;
            target = Waypoint.points[wavepointIndex];
        }
        
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        
        if (health<=0&&gameObject!=null)
        {
            PlayerStats.Money += addGold();
            Destroy(gameObject);
        }
        healthBar.fillAmount = health / startHealth;

    }
    public int addGold()
    {
        return worth;
    }
}