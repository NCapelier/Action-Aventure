using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Fixe : MonoBehaviour
{
    //Target
    public GameObject waypointFixe;
    private Transform target;
    public GameObject player;

    //Velocity
    public Rigidbody2D rb;
    public float speed = 10f;

    //Distance
    public float enterPlayerArea = 2f;

    //Camera
    public CameraShake cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        target = waypointFixe.transform;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = target.position - transform.position;

        if (Vector2.Distance(transform.position, player.transform.position) <= enterPlayerArea)
        {
           
            Debug.Log("playerFound");
            target = player.transform;
            StartCoroutine(cameraShake.Shake(.05f, .05f));
          

        } else  

        if (Vector2.Distance(transform.position, player.transform.position) >= enterPlayerArea)
        {
            
            Debug.Log("Player Outside");
            target = waypointFixe.transform;
           
        }
         rb.velocity = dir.normalized * speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
            {
            rb.velocity = new Vector3(0, 0, 0);
        }

    }

}
