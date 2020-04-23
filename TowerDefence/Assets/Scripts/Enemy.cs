using System.Collections;

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
            return;
        }
        else
        {
            wavepointIndex++;
            target = Waypoint.points[wavepointIndex];
        }
        
    }
}