using System.Collections;
using UnityEngine;
using Player;

public class BulletBehaviour : MonoBehaviour
{
    /// <summary>
    /// XP_Makes the behaviour of the ennemy3's Bullet
    /// </summary>

    [Header("Stats")]
    [Range(0.1f, 3f)]
    public float bulletSpeed;
    [Range(1f, 10f)]
    public float freezingTime;
    private float distanceToSwitchStatement = 0.1f;

    [Header("References")]
    private Rigidbody2D bulletRb;

    public GameObject enemyParent;
    private Vector3 locationInfo;

    [Header("Etats")]
    private bool arrived;
    private bool goEnemy;
    private bool timeToGo;

    bool asDeltDamages = false;



    void Start()
    {

        arrived = false;
        goEnemy = false;
        timeToGo = false;

        locationInfo = PlayerManager.Instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (arrived == true && goEnemy == false)
        {
            goEnemy = true;
            StartCoroutine("Activation");

        }


        if (arrived == false && goEnemy == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, locationInfo, bulletSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, locationInfo) <= distanceToSwitchStatement)
            {
                arrived = true;
            }
        }
        else if (goEnemy == true && arrived == true && timeToGo == true)
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerController"))
        {
            //Lancer coroutine de dégats - Draine votre barre de lumière.
            if (asDeltDamages == false)
            {
                PlayerManager.Instance.TakeDamages = 5;
            }
            asDeltDamages = true;
        }

    }

    IEnumerator Activation()
    {

        arrived = true;
        yield return new WaitForSeconds(freezingTime);
        timeToGo = true;
    }


}
