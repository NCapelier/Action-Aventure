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

        [Range(0.001f, 15f)]
        [SerializeField] float torchDetectRange = 5f;

        CircleCollider2D eyeForTorches;
        GameObject targetTorch = null;
        Torch torchLight = null;

        bool torchCaught = false;
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
            MoveToTorch();
            MoveToLight();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Torch" && torchCaught == false)
            {
                GetTorch(collision.gameObject);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Torch" && torchCaught == false)
            {
                GetTorch(collision.gameObject);
            }
        }

        #region Movement methods
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
            if (!focusingPlayer || targetTorch != null)
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
                    torchCaught = false;
                    StartCoroutine(RedetectTorch());
                    EnemyRb.velocity = Vector2.zero;
                }

                if (targetTorch != null && !focusingPlayer)
                {
                    EnemyRb.velocity = (targetTorch.transform.position - transform.parent.transform.position).normalized * moveSpeed * Time.deltaTime;
                }
            }
        }
        #endregion

        #region Torch detection methods
        void GetTorch(GameObject caughtTorch)
        {
            Debug.Log("Torch Detected !");
            torchLight = caughtTorch.GetComponentInParent<Torch>();

            if (torchLight.isLit)
            {
                torchCaught = true;
                Debug.Log("Lit Torch. To chase.");
                targetTorch = caughtTorch;
                eyeForTorches.enabled = false;
            }
        }

        IEnumerator RedetectTorch()
        {
            eyeForTorches.radius = torchDetectRange * 0.01f;
            eyeForTorches.enabled = true;

            while (eyeForTorches.radius < torchDetectRange && targetTorch == null)
            {
                yield return new WaitForSeconds(0.0001f);
                eyeForTorches.radius += torchDetectRange * 0.01f;
            }
            
        }
        #endregion
    }
}