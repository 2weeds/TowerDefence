﻿using System.Collections;

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;
    void Start()
    {
        target = Waypoint.points[0];
    }
    void Update()
    {
        if (target!=null)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWayPoint();
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
}