using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Enemy3Behaviour : MonoBehaviour
{
    /// <summary>
    /// XP_Ce script permet de faire fonctionner l'enemy 3 avec les features suivantes :
    /// Tir; Replis; 
    /// </summary>

    [Header("Stats")]
    [Range(0.1f, 300f)]
    public float speed;
    [Range(0.1f, 10f)]
    public float detectionRange;
    [Range(0.1f, 10f)]
    public float nearRange;

    //CooldownShot
    private float timeBtwShots;
    public float startTimeBtwShots;

    [Header("References")]
    public GameObject shot;
    private Rigidbody2D rbEnemy3;

    [Header("Etat")]
    private bool attackAvailable;

    void Start()
    {
        rbEnemy3 = GetComponent<Rigidbody2D>();

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = PlayerManager.Instance.transform.position - transform.position;

        if (Vector2.Distance(PlayerManager.Instance.transform.position, transform.position) <= detectionRange && Vector2.Distance(PlayerManager.Instance.transform.position, transform.position) >= nearRange)
        {
            rbEnemy3.velocity = new Vector3(0f, 0f, 0f);
            Debug.Log("Found");

            if(attackAvailable == true) {
                Enemy3Attack();
            }
            else
            {
                if (timeBtwShots <=0)
                {
                    timeBtwShots = startTimeBtwShots;
                    attackAvailable = true;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }
        }

        if (Vector2.Distance(PlayerManager.Instance.transform.position, transform.position) <= nearRange)
        {
            Debug.Log("Recall");
            attackAvailable = false;
            rbEnemy3.velocity = dir.normalized * -speed * Time.deltaTime;
        }
    }

    private void Enemy3Attack()
    {
      GameObject bullet =  Instantiate(shot, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletBehaviour>().enemyParent = this.gameObject;
        attackAvailable = false;
    }
}
