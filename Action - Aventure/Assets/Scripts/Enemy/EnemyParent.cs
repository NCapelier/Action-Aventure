using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// NCO - Parent class of every enemy object
    /// </summary>
    public abstract class EnemyParent : MonoBehaviour
    {
        #region Variables

        [HideInInspector] public int hp;
        [Range(1, 50)]
        [SerializeField] int maxHp = 10;

        #endregion

        #region Properties

        /// <summary>
        /// used to deal damages to the entity
        /// </summary>
        public int TakeDamages
        {
            set
            {
                hp -= value;
            }
        }

        /// <summary>
        /// used to give health points to the entity
        /// </summary>
        public int Heal
        {
            set
            {
                hp += value;
            }
        }

        #endregion

        void Update()
        {

        }

        /// <summary>
        /// Avoids the hp to exceed the hp cap and lauched the Death() method if hp < 0
        /// </summary>
        public virtual void UpdateHp()
        {
            if (hp > maxHp)
            {
                hp = maxHp;
            }
            if (hp <= 0)
            {
                Death();
            }
        }

        /// <summary>
        /// override this method to kill the entity
        /// </summary>
        public virtual void Death()
        {
            //death
        }

    }
}