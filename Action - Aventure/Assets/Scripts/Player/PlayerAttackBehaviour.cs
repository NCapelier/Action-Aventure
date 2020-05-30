using System.Collections;
using UnityEngine;
using Enemy;
using Boss;

namespace Player
{
    /// <summary>
    /// NCO - Player's attack behaviour --> attached to the Attack object
    /// </summary>
    public class PlayerAttackBehaviour : MonoBehaviour
    {

        #region Variables

        // editor variables

        [Range(0f, 5f)]
        [SerializeField] float lifeTime = 1;

        [Range(0, 50)]
        [SerializeField] int damages = 1;

        public GameObject spriteObject = null;
        Animator fxAnim = null;


        #endregion

        void Start()
        {
            StartCoroutine(LifeCycle());

            //PlayerManager.Instance.contactAttack.PlayAttackSound();

            fxAnim = spriteObject.GetComponent<Animator>();
            fxAnim.SetBool("isAttacking", true);
        }

        void Update()
        {
            fxAnim.SetFloat("XDirection", PlayerManager.Instance.aimBehaviour.horizontal);
            fxAnim.SetFloat("YDirection", PlayerManager.Instance.aimBehaviour.vertical);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Enemy1") || collision.CompareTag("Enemy2") || collision.CompareTag("Enemy3") || collision.CompareTag("Enemy4"))
            {
                collision.GetComponent<EnemyParent>().TakeDamages = damages * (int)PlayerManager.Instance.contactAttack.loading;

            }
        }

        /// <summary>
        /// Applies the lifetime on the object
        /// </summary>
        /// <returns></returns>
        IEnumerator LifeCycle()
        {
            yield return new WaitForSeconds(lifeTime);
            PlayerManager.Instance.contactAttack.loading = 1;
            PlayerManager.Instance.contactAttack.isAttacking = false;
            PlayerManager.Instance.contactAttack.routine = true;
            Destroy(gameObject);
        }

        public void GetAnimationEvent(string EventMessage)
        {
            if (EventMessage.Equals("AttackEnded"))
            {
                fxAnim.SetBool("isAttacking", false);
            }
            if (EventMessage.Equals("BigAttackEnded"))
            {
                fxAnim.SetBool("isBigAttack", false);
            }
        }


    }
}