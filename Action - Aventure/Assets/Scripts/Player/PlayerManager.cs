using UnityEngine;
using Management;
using GameSound;
using GameManagement;


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
        public PotionBottles potionBottles = null;

        // curent health points of the player
        [HideInInspector] public int currentHp = 1;

        // current max hp depending on current echelon
        [HideInInspector] public int currentMaxHp = 1;

        // editor variables

        [Range(1,200)]
        public int maxHp = 100;

        [Range(1, 10)]
        [SerializeField] int hpEchelonNumber = 4;

        [HideInInspector] public bool invincible = false;

        #endregion

        #region Properties

        /// <summary>
        /// used to deal damages to the entity
        /// </summary>
        public int TakeDamages
        {
            set
            {
                if (invincible)
                    return;

                currentHp -= value;

                //Animation
                controller.HitAnimation();


                if (currentHp <= 0)
                {
                    Death();
                }
                else
                {
                    UpdateMaxHp();

                    //Sound
                    AudioManager.Instance.Play("Player_hurt");
                }
            }
        }

        /// <summary>
        /// used to give health points to the entity
        /// </summary>
        public int Heal
        {
            set
            {
                if (!GameManager.Instance.gameState.potionGet)
                    return;
                currentHp += value;

                if (currentHp > currentMaxHp)
                {
                    currentHp = currentMaxHp;
                }
            }
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            MakeSingleton(true);
        }

        void Start()
        {
            InitializeHp();
        }

        void Update()
        {

        }

        #endregion

        /// <summary>
        /// initialize HPs variables on start
        /// </summary>
        void InitializeHp()
        {
            currentMaxHp = maxHp;
            currentHp = maxHp;
        }

        /// <summary>
        /// Updates the maximum hp of the player depending on its current hp
        /// </summary>
        void UpdateMaxHp()
        {
            for(int i = 0; i < hpEchelonNumber; i++)
            {
                if (currentHp <= currentMaxHp - maxHp / hpEchelonNumber)
                {
                    currentMaxHp -= maxHp / hpEchelonNumber;
                }
            }
        }

        /// <summary>
        /// override this method to kill the entity
        /// </summary>
        void Death()
        {
            //code here

            //Cue the death animation with this function
            // controller.DeathAnimation();

            //Sound
            AudioManager.Instance.Play("Player_death");

            GameManager.Instance.gameState.playerDead = true;
        }

    }

}