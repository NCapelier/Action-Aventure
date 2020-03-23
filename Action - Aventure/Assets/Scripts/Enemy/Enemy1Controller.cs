﻿using System.Collections;
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

        //rigidbody2D of this enemy
        Rigidbody2D EnemyRb = null;

        // editor variables : enemy movement variables
        [Range(0f, 500f)]
        [SerializeField] float moveSpeed = 1;

        [Range(0.5f, 25f)]
        [SerializeField] float contactDistance = 1f;

        [Range(15f, 30f)]
        [SerializeField] float playerDetectRange = 20f;

        [Range(8f, 15f)]
        [SerializeField] float lightDetectExtra = 10f;

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
            MoveToLight();
            MoveToPlayer();
        }
        
        /// <summary>
        /// Moves this enemy towards the player until it's close enouth depending on contactDistance
        /// </summary>
        void MoveToPlayer()
        {
            if((Vector2.Distance(PlayerManager.Instance.transform.position, transform.parent.transform.position).isBetween(contactDistance, false, playerDetectRange, true)) && (LanternManager.Instance.hideLight.currentLightState == lightState.Displayed))
            {
                EnemyRb.velocity = (PlayerManager.Instance.transform.position - transform.parent.transform.position).normalized * moveSpeed * Time.deltaTime;
            }
            else
            {
                EnemyRb.velocity = Vector2.zero;
            }
        }

        void MoveToLight()
        {
            if ((Vector2.Distance(LanternManager.Instance.transform.position, transform.parent.transform.position).isBetween(playerDetectRange, false, playerDetectRange + lightDetectExtra, true)) && (LanternManager.Instance.flashLight.currentLightStrength == lightStrength.Strengthful))
            {
                EnemyRb.velocity = (LanternManager.Instance.transform.position - transform.parent.transform.position).normalized * moveSpeed * Time.deltaTime;
            }
            else
            {
                EnemyRb.velocity = Vector2.zero;
            }
        }
    }
}