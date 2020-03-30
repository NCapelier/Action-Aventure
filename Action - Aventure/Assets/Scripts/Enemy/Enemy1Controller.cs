using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Lantern;
using Puzzle;

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

        [Range(0f, 20f)]
        [SerializeField] float playerDetectRange = 4f;

        [Range(0f, 8f)]
        [SerializeField] float lightDetectExtra = 4f;

        [Range(0f, 15f)]
        [SerializeField] float torchDetectRange = 5f;

        CircleCollider2D eyeForTorches;
        GameObject targetTorch = null;
        Torch torchLight = null;

        bool focusingPlayer = false;

        #endregion

        void Awake()
        {
            
        }
        
        void Start()
        {
            EnemyRb = GetComponentInParent<Rigidbody2D>();
            eyeForTorches = GetComponent<CircleCollider2D>();
            eyeForTorches.radius = 0.01f;
            StartCoroutine(RedetectTorch());
        }
        
        void Update()
        {
            MoveToPlayer();
            MoveToLight();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Torch")
            {
                Debug.Log("Torch Detected");
                torchLight = collision.gameObject.GetComponentInParent<Torch>();

                if (torchLight.isLit)
                {
                    targetTorch = collision.gameObject;
                    eyeForTorches.enabled = false;
                }
            }
        }
        /// <summary>
        /// Moves this enemy towards the player until it's close enouth depending on contactDistance
        /// </summary>
        void MoveToPlayer()
        {
            if((Vector2.Distance(PlayerManager.Instance.transform.position, transform.parent.transform.position).isBetween(contactDistance, false, playerDetectRange, true)) && (LanternManager.Instance.hideLight.currentLightState == lightState.Displayed))
            {
                EnemyRb.velocity = (PlayerManager.Instance.transform.position - transform.parent.transform.position).normalized * moveSpeed * Time.deltaTime;
                focusingPlayer = true;
            }
            else
            {
                EnemyRb.velocity = Vector2.zero;
                focusingPlayer = false;
            }
        }

        /// <summary>
        /// CHB -- Moves enemy towards Will o' the wisp until it can detect the player
        /// </summary>
        void MoveToLight()
        {
            if (!focusingPlayer)
            {
                if ((Vector2.Distance(LanternManager.Instance.transform.position, transform.parent.transform.position).isBetween(0.1f, false, playerDetectRange + lightDetectExtra, true)) && (LanternManager.Instance.flashLight.currentLightStrength == lightStrength.Strengthful))
                {
                    EnemyRb.velocity = (LanternManager.Instance.transform.position - transform.parent.transform.position).normalized * moveSpeed * Time.deltaTime;
                }
                else
                {
                    EnemyRb.velocity = Vector2.zero;
                }
            }
            
        }

        void MoveToTorch()
        {
            if(targetTorch != null)
            {
                if (!Vector2.Distance(targetTorch.transform.position, transform.parent.transform.position).isBetween(contactDistance, false, torchDetectRange, true) || !torchLight.isLit)
                {
                    targetTorch = null;
                    torchLight = null;
                    StartCoroutine(RedetectTorch());
                    EnemyRb.velocity = Vector2.zero;
                }

                if (targetTorch != null && !focusingPlayer)
                {
                    EnemyRb.velocity = (targetTorch.transform.position - transform.parent.transform.position).normalized * moveSpeed * Time.deltaTime;
                }
            }
        }

        IEnumerator RedetectTorch()
        {
            eyeForTorches.radius = torchDetectRange * 0.01f;
            eyeForTorches.enabled = true;

            while (eyeForTorches.radius < torchDetectRange && targetTorch == null)
            {
                yield return new WaitForSeconds(0.0005f);
                eyeForTorches.radius += torchDetectRange * 0.01f;
            }
            
        }
    }
}