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

        // (array) curent health points of the player
        [HideInInspector] public int[] hp;

        // (int) curent health points of the player
        [HideInInspector] public int currentHp;

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
            hp = new int[hpEchelonNumber];
            for (int i = 0; i < hp.Length; i++)
            {
                hp[i] = maxHp / hpEchelonNumber;
            }
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