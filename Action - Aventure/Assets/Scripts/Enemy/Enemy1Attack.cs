using UnityEngine;
using Player;

namespace Enemy
{
    /// <summary>
    /// AM - Attacks the player if in range
    /// </summary>
    public class Enemy1Attack : MonoBehaviour
    {

        #region Variables

        //editor variables

        [Range(0, 200)]
        [SerializeField] int damage = 0;

        [Range(0, 20)]
        [SerializeField] float attackRange = 0;

        [Range(0, 10)]
        [SerializeField] float cooldown = 0;

        //time since this enemy attacked
        float lastAttackTime = 1;

        //distance between player and this enemy
        float distance = 0;

        public Animator anim;
        public GameObject controller;
        public Animator eyesAnim;
        #endregion

        void Start()
        {
            anim = controller.GetComponent<Animator>(); 
        }

        void Update()
        {
            AttackPlayer();
        }

        /// <summary>
        /// Attacks the player if in range
        /// </summary>
        void AttackPlayer()
        {
            distance = Vector2.Distance(PlayerManager.Instance.transform.position, gameObject.transform.position);
            //Attack if the player is in range and cf == 0
            if (distance < attackRange && Time.time > lastAttackTime + cooldown)
            {
                anim.SetBool("isAttacking", true);
                eyesAnim.SetBool("isAttacking", true);

                PlayerManager.Instance.TakeDamages = damage;
                Debug.Log("Damage");
                //Record the time of the last attack
                lastAttackTime = Time.time;
            }
        }
    }
}