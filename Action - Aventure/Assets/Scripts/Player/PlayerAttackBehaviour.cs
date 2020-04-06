using System.Collections;
using UnityEngine;
using Enemy;

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

        #endregion

        void Awake()
        {
            
        }
        
        void Start()
        {
            StartCoroutine(LifeCycle());
        }
        
        void Update()
        {
            
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

    }
}