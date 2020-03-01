using UnityEngine;
using Management;

namespace Player
{
    /// <summary>
    /// NCO - General management of the Player object.
    /// </summary>
    public class PlayerManager : Singleton<PlayerManager>
    {

        #region Variables

        // all scripts of this prefab
        public PlayerController controller = null;
        public PlayerContactAttack contactAttack = null;
        public PlayerAimBehaviour aimBehaviour = null;

        // curent health points of the player
        [HideInInspector] public int hp;

        // editor variables

        [Range(1,50)]
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

        void Awake()
        {
            MakeSingleton(false);
        }

        void Start()
        {

        }

        void Update()
        {

        }

        /// <summary>
        /// Avoids the hp to exceed the hp cap and lauched the Death() method if hp < 0
        /// </summary>
        void UpdateHp()
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
        void Death()
        {
            //death
        }

    }

}