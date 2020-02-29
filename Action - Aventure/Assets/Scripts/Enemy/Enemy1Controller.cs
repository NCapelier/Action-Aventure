using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Lantern;

namespace Enemy
{
    /// <summary>
    /// NCO - Controller of the first enemy
    /// </summary>
    public class Enemy1Controller : MonoBehaviour
    {

        #region Variables

        Rigidbody2D EnemyRb = null;

        [Range(0f, 500f)]
        [SerializeField] float moveSpeed = 1;

        float contactDistance = 1f;

        #endregion

        void Awake()
        {
            
        }
        
        void Start()
        {
            EnemyRb = GetComponentInParent<Rigidbody2D>();
        }
        
        void Update()
        {
            MoveToPlayer();
        }
        
        void MoveToPlayer()
        {
            if((Vector2.Distance(PlayerManager.Instance.transform.position, transform.parent.transform.position) > contactDistance) && (LanternManager.Instance.hideLight.currentLightState == lightState.Displayed))
            {
                EnemyRb.velocity = (PlayerManager.Instance.transform.position - transform.parent.transform.position).normalized * moveSpeed * Time.deltaTime;
            }
            else
            {
                EnemyRb.velocity = Vector2.zero;
            }
        }
    }
}