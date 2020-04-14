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

        bool focusingPlayer = false;

        // Animator
        private Animator anim;


        #endregion

        void Awake()
        {
            
        }
        
        void Start()
        {
            EnemyRb = GetComponentInParent<Rigidbody2D>();
            anim = gameObject.GetComponent<Animator>();
        }
        
        void Update()
        {
            MoveToPlayer();
            MoveToLight();
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

                //Animation
                anim.SetBool("Aggro", true);
            }
            else
            {
                EnemyRb.velocity = Vector2.zero;
                focusingPlayer = false;

                //Animation
                anim.SetBool("Aggro", false);
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

                    //Animation
                    anim.SetBool("Aggro", true);
                }
                else
                {
                    EnemyRb.velocity = Vector2.zero;

                    //Animation
                    anim.SetBool("Aggro", false);
                }
            }
            
        }

        /// <summary>
        /// Animation Fonction For Attack, Death and animator Eyes
        /// </summary>
        
        public void BlobDeathAnimation()
        {
            anim.SetBool("isDead", true);
        }
        public void BlobAttackAnim()
        {
            anim.SetBool("isAttacking", true);

        }

        public void BlobDamageAnim()
        {
            anim.SetBool("isHit", true);
        }

        //Get Animation Event from AttackAnimation 
        public void GetAnimationEvent(string eventMessage)
        {
            if (eventMessage.Equals("AttackEnded"))
            {
                anim.SetBool("isAttacking", false);
            }

            if (eventMessage.Equals("EyeAggro"))
            {
                //Set le bool de l'animator des yeux en true, je ne sais pas comment aller chercher cet animator 
                //anim.SetBool("Aggro", true);
            }

            if (eventMessage.Equals("Hit"))
            {
                anim.SetBool("isHit", false);
            }

        }

    }
}