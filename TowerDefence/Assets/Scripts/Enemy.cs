using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;
    public float startSpeed = 10f;

    [HideInInspector]

    public float startHealth = 100f;
    private float health;

    //public int worth = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;
    void Start()
    {
        target = Waypoint.points[0];
        speed = startSpeed;
        health = startHealth;
    }

    void Update()
    {
        if (target!=null)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, target.position) <= 0.2)
            {
                
                GetNextWayPoint();
                transform.Rotate(dir);
            }

        }
       
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / 50f;

        if (health <= 0 && !isDead)
        {
            Die();
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
    void Die()
    {
        isDead = true;

        ////PlayerStats.Money += worth;

        //GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        ////WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}