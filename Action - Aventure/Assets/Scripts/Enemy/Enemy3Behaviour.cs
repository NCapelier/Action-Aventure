using UnityEngine;
using Player;
using Lantern;
using GameManagement;

namespace Enemy
{
    public class Enemy3Behaviour : EnemyParent
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
        public float Cooldown;

        [Header("References")]
        public GameObject shot;
        private Rigidbody2D rbEnemy3;

        [Header("Etat")]
        private bool attackAvailable;

        public Animator bodyAnimator = null, eyeAnimator = null;

        void Start()
        {
            EnemyStart();
            rbEnemy3 = GetComponent<Rigidbody2D>();

            timeBtwShots = Cooldown;
        }

        // Update is called once per frame
        void FixedUpdate()
        {

            bodyAnimator.SetFloat("XMovement", rbEnemy3.velocity.x);
            bodyAnimator.SetFloat("YMovement", rbEnemy3.velocity.y);

            eyeAnimator.SetFloat("XMovement", rbEnemy3.velocity.x);
            eyeAnimator.SetFloat("YMovement", rbEnemy3.velocity.y);

            if (GameCanvasManager.Instance.dialog.runningConversation)
            {
                rbEnemy3.velocity = Vector2.zero;
                return;
            }
            Vector2 dir = PlayerManager.Instance.transform.position - transform.position;

            if (LanternManager.Instance.hideLight.currentLightState == lightState.Hidden)
            {
                timeBtwShots = Cooldown;
            }


            if (Vector2.Distance(PlayerManager.Instance.transform.position, transform.position) <= detectionRange && Vector2.Distance(PlayerManager.Instance.transform.position, transform.position) >= nearRange)
            {
                rbEnemy3.velocity = new Vector3(0f, 0f, 0f);
                bodyAnimator.SetBool("isAggro", true);
                eyeAnimator.SetBool("isAggro", true);

                if (attackAvailable == true && LanternManager.Instance.hideLight.currentLightState == lightState.Displayed)
                {
                    Enemy3Attack();
                }
                else
                {
                    if (timeBtwShots <= 0)
                    {
                        timeBtwShots = Cooldown;
                        attackAvailable = true;
                    }
                    else
                    {
                        timeBtwShots -= Time.deltaTime;
                    }
                }
            }
            else
            {
                bodyAnimator.SetBool("isAggro", false);
                eyeAnimator.SetBool("isAggro", false);
            }

            if (Vector2.Distance(PlayerManager.Instance.transform.position, transform.position) <= nearRange)
            {
                attackAvailable = false;
                rbEnemy3.velocity = dir.normalized * -speed;
            }
        }

        private void Enemy3Attack()
        {
            bodyAnimator.SetBool("isAttacking", true);
            eyeAnimator.SetBool("isAttacking", true);
            attackAvailable = false;
            GameObject bullet = Instantiate(shot, transform.position, Quaternion.identity);
            bullet.GetComponent<BulletBehaviour>().enemyParent = this.gameObject;
        }

        public void GetAnimationEvent(string EventMessage)
        {
            if (EventMessage.Equals("isHit"))
            {
                bodyAnimator.SetBool("isHit", false);
                eyeAnimator.SetBool("isHit", false);
            }

        }
    }

}