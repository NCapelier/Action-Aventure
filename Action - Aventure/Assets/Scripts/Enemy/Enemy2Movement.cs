using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{

    //Target
    public GameObject waypoints;
    private Transform target;
    private int waypointIndex = 0;
    public GameObject player;

    //Velocity
    public Rigidbody2D rb;
    public float speed = 10f;

    //distance

    public float enterPlayerArea = 2f;
    public float distanceToSwitchTargetWaypoints = 0.5f;

    //Clock
    public bool clockOneEnded;
    public bool clockTwoEnded;
    public bool playerNotFound;

    //Camera
    public CameraShake cameraShake;


    private void Start()
    {
        target = waypoints.GetComponent<GetWaypoints>().points[0];

        clockOneEnded = true;
      
        playerNotFound = true;

        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        Vector2 dir = target.position - transform.position;

        if (Vector2.Distance(transform.position, player.transform.position) <= enterPlayerArea)
        {
            playerNotFound = false;
            Debug.Log("playerFound");
            target = player.transform;
            StartCoroutine(cameraShake.Shake(.05f, .05f));

            rb.velocity = dir.normalized * speed * Time.deltaTime;

        }
        if (Vector2.Distance(transform.position, player.transform.position) >= enterPlayerArea)
        {
            playerNotFound = true;
            Debug.Log("Player Outside");
            target = waypoints.GetComponent<GetWaypoints>().points[waypointIndex];
            
            

            if (Vector2.Distance(transform.position, target.position) <= distanceToSwitchTargetWaypoints)
            {
                GetNextWaypoints();
            }
        }

        

        
        if (clockTwoEnded == true)
        {
            rb.velocity = dir.normalized * speed * Time.deltaTime;
            clockOne();


        }
        //Start clocktwo
        if (clockOneEnded == true)
        {
           
            rb.velocity = new Vector3(0, 0, 0);
            StartCoroutine(cameraShake.Shake(.05f, .05f));
            clockTwo();
       

        }

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

    private void clockOne()
    {
        StartCoroutine("Clock1");
    }

    private void clockTwo()
    {
        StartCoroutine("Clock2");
    }


    IEnumerator Clock1()
    {
            clockTwoEnded = false;
            yield return new WaitForSecondsRealtime(0.5f);
            clockOneEnded = true;
            Debug.Log("clockOne Move");
    }
    //Stop Mouvement
    IEnumerator Clock2()
    {
            clockOneEnded = false;
            yield return new WaitForSecondsRealtime(0.5f);
            clockTwoEnded = true;
            Debug.Log("clockTwo Move");
    }
}

