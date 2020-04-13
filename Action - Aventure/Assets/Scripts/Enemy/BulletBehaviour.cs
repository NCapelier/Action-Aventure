using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class BulletBehaviour : MonoBehaviour
{
    /// <summary>
    /// XP_Makes the behaviour of the ennemy3 Bullet
    /// </summary>

    [Header("Stats")]
    public float bulletSpeed;

    private Rigidbody2D bulletRb;

    private Transform player;


    private bool arrived;
    private bool goEnemy;
    private bool timeToGo;
    public GameObject enemyParent;
    private float distanceToSwitchStatement = 0.1f;
    private Vector3 locationInfo;


    void Start()
    {
        
        arrived = false;
        goEnemy = false;
        timeToGo = false;
        player = PlayerManager.Instance.transform;

        locationInfo = PlayerManager.Instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (arrived == true && goEnemy == false)
        {
            StartCoroutine("Activation");


        }
       
        

            if (arrived == false && goEnemy == false)
            {
            transform.position = Vector2.MoveTowards(transform.position, locationInfo, bulletSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, locationInfo) <= distanceToSwitchStatement)
                {
                    arrived = true;
                    Debug.Log("arrivé");
                    
                }
            }
             else if (goEnemy == true && arrived == true && timeToGo==true)
             {
            transform.position = Vector2.MoveTowards(transform.position, enemyParent.transform.position, bulletSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, enemyParent.transform.position) <= distanceToSwitchStatement)
                {
                arrived = false;
                timeToGo = false;
                goEnemy = false;
                gameObject.SetActive(false);
                }
             }

    }

  IEnumerator Activation()
    {
       
        goEnemy = true;
        arrived = true;
        Debug.Log("startEnum");
        yield return new WaitForSeconds(1f);
        timeToGo = true;
    }

   
}
