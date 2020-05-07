using System.Collections;
using UnityEngine;
using Enemy;
using GameSound;

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

        void Awake()
        {
            
        }
        
        void Start()
        {
            StartCoroutine(LifeCycle());

            AudioManager.Instance.Play("Lantern_light_strike");

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
            if(collision.CompareTag("Enemy"))
            {
                // damages --> ref enemy parent
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
            PlayerManager.Instance.contactAttack.loading = 0;
            PlayerManager.Instance.contactAttack.isAttacking = false;
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