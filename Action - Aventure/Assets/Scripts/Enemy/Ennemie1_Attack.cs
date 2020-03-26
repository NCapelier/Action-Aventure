using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Ennemie1_Attack : MonoBehaviour
{
    public float attackRange;
    public int damage;
    public float lastAttackTime = 1;
    public float cooldown;
    float distance = Vector2.Distance(PlayerManager.Instance.transform.position, gameObject.transform.position);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Attack if the player is in range
        if (distance < attackRange)

        {   //check when the last attack was perform
            if (Time.time > lastAttackTime + cooldown)

            {   //Attack
                target.SendMessage("Take Damage", damage);

                //Record the time of the last attack
                lastAttackTime = Time.time;
            }
        }
    }
}
