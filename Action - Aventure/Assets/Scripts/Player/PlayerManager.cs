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
        [HideInInspector] public int currentHp = 1;

        // current max hp depending on current echelon
        [HideInInspector] public int currentMaxHp = 1;

        // editor variables

        [Range(1,200)]
        [SerializeField] int maxHp = 100;

        [Range(1, 10)]
        [SerializeField] int hpEchelonNumber = 4;

        #endregion

        #region Properties

        /// <summary>
        /// used to deal damages to the entity
        /// </summary>
        public int TakeDamages
        {
            set
            {

            }
        }

        /// <summary>
        /// used to give health points to the entity
        /// </summary>
        public int Heal
        {
            set
            {

            }
        }

        #endregion

        void Awake()
        {
            MakeSingleton(false);
        }

        void Start()
        {
            //StartHp();
        }

        void Update()
        {

        }

        /// <summary>
        /// Initializes the hp array and spreads all the hp in the different echelons
        /// </summary>
        void StartHp()
        {

        }

        /// <summary>
        /// Avoids the hp to exceed the hp cap and lauched the Death() method if hp < 0
        /// </summary>
        void UpdateHp()
        {

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