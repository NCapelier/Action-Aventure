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
    public int attackDirection;
    public int direction;
    public bool playerFound;

    //Velocity
    public Rigidbody2D rb;
    public float speed = 10f;

    //distance

    public float enterPlayerArea = 2f;
    public float distanceToSwitchTargetWaypoints = 0.5f;
    public float ennemiRangeAttack;

    //Clock
    public bool clockOneEnded;
    public bool clockTwoEnded;
    public bool playerNotFound;

    //Camera
    public CameraShake cameraShake;

     //Attaque
    public float attackSpeed;
    public bool canAttack;
    public float warningTime;
    public bool isAttacking;
    public float immobilizationTime;
    public Vector3 move;

    //Zone de dégats
    public GameObject LeftAttack;
    public GameObject RightAttack;
    public GameObject UpAttack;
    public GameObject DownAttack;



    private void Start()
    {
        target = waypoints.GetComponent<GetWaypoints>().points[0];

        clockTwoEnded = true;
      
        playerNotFound = true;

        rb = GetComponent<Rigidbody2D>();

        canAttack = true;

        rb.velocity = new Vector3(0, 0, 0);

        LeftAttack.SetActive(false);
        RightAttack.SetActive(false);
        UpAttack.SetActive(false);
        DownAttack.SetActive(false);

        playerFound = false;

    }

    private void Update()
    {
        Vector2 dir = target.position - transform.position;

        Direction();
       
        if (Vector2.Distance(transform.position, player.transform.position) <= enterPlayerArea)
        {
            playerFound = true;
            Debug.Log("playerFound");
            target = player.transform;
            rb.velocity = dir.normalized * speed * Time.deltaTime;
            if (Vector2.Distance(transform.position, player.transform.position) >= ennemiRangeAttack)
            {
                StartCoroutine(cameraShake.Shake(.05f, .05f));
            }

        }
        else if (Vector2.Distance(transform.position, player.transform.position) >= enterPlayerArea)
        {
            playerNotFound = true;
            Debug.Log("Player Outside");
            target = waypoints.GetComponent<GetWaypoints>().points[waypointIndex];

            if (clockTwoEnded == true)
            {
                rb.velocity = dir.normalized * speed * Time.deltaTime;
                clockOne();


            }
            //Start clocktwo
            else if (clockOneEnded == true && playerFound == false)
            {

                rb.velocity = new Vector3(0, 0, 0);


                if (Vector2.Distance(transform.position, player.transform.position) >= ennemiRangeAttack)
                {
                    StartCoroutine(cameraShake.Shake(.05f, .05f));
                }
                clockTwo();


            }

            if (Vector2.Distance(transform.position, target.position) <= distanceToSwitchTargetWaypoints)
            {
                GetNextWaypoints();
            }
        }

        

        
       
        if (Vector2.Distance(transform.position, player.transform.position) <= ennemiRangeAttack)
        {
            rb.velocity = new Vector3(0, 0, 0);
            StartCoroutine(Attack());

            if (isAttacking == true)
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
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

    void Direction()
    {
        move = (player.transform.position - transform.position).normalized;

        if (move != Vector3.zero)
        {
            if (move.y >= Mathf.Sqrt(2) / 2 && move.x <= Mathf.Sqrt(2) / 2 && move.x >= -Mathf.Sqrt(2) / 2)
            {
                direction = 0;        //up
            }
            else if (move.y <= -Mathf.Sqrt(2) / 2 && move.x <= Mathf.Sqrt(2) / 2 && move.x >= -Mathf.Sqrt(2) / 2)
            {
                direction = 2;        //down               
            }
            else if (move.x >= Mathf.Sqrt(2) / 2 && move.y <= Mathf.Sqrt(2) / 2 && move.y >= -Mathf.Sqrt(2) / 2)
            {
                direction = 1;        //right                
            }
            else if (move.x <= -Mathf.Sqrt(2) / 2 && move.y <= Mathf.Sqrt(2) / 2 && move.y >= -Mathf.Sqrt(2) / 2)
            {
                direction = 3;        //left 
            }
        }
    }

    IEnumerator Attack()
    {
        if (canAttack == true)
        {

            canAttack = false;
            isAttacking = true;

            rb.velocity = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(warningTime);

            switch (direction)
            {
                case 0:
                    Debug.Log("Attaque Haute");
                    UpAttack.SetActive(true);
                    break;
                case 1:
                    Debug.Log("Attaque Droite");
                    RightAttack.SetActive(true);
                    break;
                case 2:
                    Debug.Log("Attaque En bas");
                    DownAttack.SetActive(true);
                    break;
                case 3:
                    Debug.Log("Attaque Gauche");
                    LeftAttack.SetActive(true);
                    break;
                default:
                    break;
            }

            yield return new WaitForSeconds(0.001f);


            yield return new WaitForSeconds(immobilizationTime);

            LeftAttack.SetActive(false);
            RightAttack.SetActive(false);
            UpAttack.SetActive(false);
            DownAttack.SetActive(false);
            isAttacking = false;

            yield return new WaitForSeconds(attackSpeed);

            canAttack = true;

        }
    }
}

