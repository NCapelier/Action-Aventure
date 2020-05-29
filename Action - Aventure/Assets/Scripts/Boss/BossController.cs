﻿using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    /// <summary>
    /// NCO
    /// </summary>
    public class BossController : MonoBehaviour
    {
        #region Variables

        Rigidbody2D rb = null;
        public PolygonCollider2D physicCollider = null, triggerCollider = null;

        public bossState currentBossState = bossState.Phase1;

        Vector2 dashDir = Vector2.zero;

        //int playerLayer, wallLayer;

        public Coroutine routine = null;

        [Header("Combat Phases")]
        [Range(0f, 20f)]
        [SerializeField] float dashSpeed = 1f;

        [HideInInspector] public bool isDashing = false;
        [HideInInspector] public bool stopDash = false;
        [HideInInspector] public bool isWeak = false;

        [Header("Phase 1")]
        public int headBandCount = 3;
        [Range(0f, 5f)]
        [SerializeField] float phase1WeakTime = 2f;

        [Header("Phase 2")]
        [Range(0f, 5f)]
        [SerializeField] float phase2WeakTime = 2f;
        [Range(0f, 5f)]
        [SerializeField] float rockInvokeTime = 2f;
        [Range(0f, 5f)]
        [SerializeField] float shadowInvokeTime = 2f;

        bool dashedOnce = false;
        bool dashedTwice = false;

        [HideInInspector] public bool touchedRock = false;

        bool isInvoking = false;

        bool invokedShadow = false;
        bool invokedRock = false;

        #endregion

        #region Unity Methods

        private void Start()
        {
            rb = BossManager.Instance.GetComponent<Rigidbody2D>();
            //playerLayer = LayerMask.NameToLayer("Player");
            //wallLayer = LayerMask.NameToLayer("Wall");
        }

        private void FixedUpdate()
        {
            switch(currentBossState)
            {
                case bossState.CutScene1:
                    break;
                case bossState.CutScene2:
                    break;
                case bossState.CutScene3:
                    break;
                case bossState.Phase1:
                    Phase1Update();
                    break;
                case bossState.Phase2:
                    Phase2Update();
                    break;
                default:
                    D.Log("Error, value is not assigned !");
                    break;
            }
        }

        #endregion

        void Phase1Update()
        {
            if(headBandCount <= 0)
            {
                currentBossState = bossState.CutScene2;
                return;
            }
            if(!isDashing && !isWeak)
            {
                Dash();
            }
            else if(stopDash)
            {
                StopDash();
            }

        }

        void Phase2Update()
        {
            if(dashedOnce && !invokedRock)
            {
                isInvoking = true;
                invokedRock = true;
                StartCoroutine(InvokeRock());
            }
            else if(dashedTwice && !invokedShadow)
            {
                isInvoking = true;
                invokedShadow = true;
                StartCoroutine(InvokeShadow());
            }

            if(!isDashing && !isWeak && !isInvoking)
            {
                Dash();
            }
            else if(stopDash)
            {
                StopDash();
            }
        }

        void Dash()
        {
            isDashing = true;
            physicCollider.enabled = false;

            dashDir = PlayerManager.Instance.transform.position - transform.position;
            rb.velocity = dashDir.normalized * dashSpeed;
        }

        void StopDash()
        {
            stopDash = false;
            isDashing = false;
            rb.velocity = Vector2.zero;
            physicCollider.enabled = true;
            if (currentBossState == bossState.Phase1)
            {
                isWeak = true;
                routine = StartCoroutine(Dash1Weakness());
            }
            else if (currentBossState == bossState.Phase2 && touchedRock)
            {
                isWeak = true;
                routine = StartCoroutine(Dash2Weakness());
            }

            if (currentBossState == bossState.Phase2)
            {
                if(dashedOnce == false)
                {
                    dashedOnce = true;
                }
                else if(dashedTwice == false)
                {
                    dashedTwice = true;
                }
            }
        }

        public IEnumerator Dash1Weakness()
        {
            yield return new WaitForSeconds(phase1WeakTime);
            isWeak = false;
        }

        public IEnumerator Dash2Weakness()
        {
            yield return new WaitForSeconds(phase2WeakTime);
            isWeak = false;
            touchedRock = false;
        }

        IEnumerator InvokeRock()
        {
            yield return new WaitForSeconds(rockInvokeTime);

            RockManager.Instance.SpawnRocks();

            // --> boss animation

            isInvoking = false;
        }

        IEnumerator InvokeShadow()
        {
            yield return new WaitForSeconds(shadowInvokeTime);

            RockManager.Instance.SpawnShadow();

            // --> boss animation

            dashedOnce = false;
            dashedTwice = false;
            isInvoking = false;
        }
    }
}