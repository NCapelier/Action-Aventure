using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    public GameObject player;


    public GameObject waypoints;
    private Transform target;
    private int waypointIndex = 0;

    public Rigidbody2D rb;

    public float speed = 10f;

    public float distanceMax = 4f;
    public float enterPlayerArea = 2f;
    public float distanceToSwitchTargetWaypoints = 0.2f;


    private void Start()
    {
        target = waypoints.GetComponent<GetWaypoints>().points[0];
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) <= enterPlayerArea)
        {
            Debug.Log("playerFound");
            target = player.transform;
        }
        if (Vector2.Distance(transform.position, player.transform.position) >= distanceMax)
        {
            Debug.Log("Player Outside");
            target = waypoints.GetComponent<GetWaypoints>().points[waypointIndex];

            if (Vector2.Distance(transform.position, target.position) <= distanceToSwitchTargetWaypoints)
            {
                GetNextWaypoints();
            }
        }


        Vector2 dir = target.position - transform.position;
        rb.velocity = dir.normalized * speed * Time.deltaTime;

       

    }

    private void GetNextWaypoints()
    {
        waypointIndex++;

        if (waypointIndex == 5)
        {
            waypointIndex = 0;
        }
        target = waypoints.GetComponent<GetWaypoints>().points[waypointIndex];

    }
}

