﻿using UnityEngine;
using Management;
using GameSound;
using GameManagement;
using System.Collections;
using Lantern;
using UnityEngine.SceneManagement;

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
        //[HideInInspector] public int currentMaxHp = 1;

        // editor variables

        [Range(1,200)]
        public int maxHp = 100;

        /*[Range(1, 10)]
        [SerializeField] int hpEchelonNumber = 4;*/

        [HideInInspector] public bool invincible = false;

        /*bool mustHeal = false;
        bool healing = false;*/

        #endregion

        #region Properties

        /// <summary>
        /// used to deal damages to the entity
        /// </summary>
        public int TakeDamages
        {
            set
            {
                if (invincible || GameManager.Instance.gameState.playerDead)
                    return;

                currentHp -= value;

                if (currentHp <= 0)
                {
                    Death();
                }
                else
                {
                    //UpdateMaxHp();

                    //Animation
                    controller.HitAnimation();

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
                /*if (!GameManager.Instance.gameState.potionGet)
                    return;*/
                currentHp += value;

                if (currentHp > maxHp)
                {
                    currentHp = maxHp;
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
            /*if(LanternManager.Instance.hideLight.currentLightState == lightState.Displayed && mustHeal && !healing)
            {
                healing = true;
                mustHeal = false;
                StartCoroutine(ChainHeal());
            }*/
        }

        #endregion

        /*IEnumerator ChainHeal()
        {
            yield return new WaitForSeconds(0.8f);
            if(currentHp != currentMaxHp)
            {
                Heal = 1;
            }
            if (currentHp != currentMaxHp && LanternManager.Instance.hideLight.currentLightState == lightState.Displayed)
            {
                StartCoroutine(ChainHeal());
            }
            else
            {
                healing = false;
            }
        }*/

        /// <summary>
        /// initialize HPs variables on start
        /// </summary>
        /*void InitializeHp()
        {
            currentMaxHp = maxHp;
            currentHp = maxHp;
        }*/

        void InitializeHp()
        {
            currentHp = maxHp;
        }

        /// <summary>
        /// Updates the maximum hp of the player depending on its current hp
        /// </summary>
        /*void UpdateMaxHp()
        {
            for(int i = 0; i < hpEchelonNumber; i++)
            {
                if (currentHp <= currentMaxHp - maxHp / hpEchelonNumber)
                {
                    currentMaxHp -= maxHp / hpEchelonNumber;
                }
            }
            if(!healing)
            {
                mustHeal = true;
            }
        }*/

        /// <summary>
        /// override this method to kill the entity
        /// </summary>
        public void Death()
        {
            //Cue the death animation with this function
            // controller.DeathAnimation();

            //Sound
            AudioManager.Instance.Play("Player_death");

            GameManager.Instance.gameState.playerDead = true;
           
        }

    }

}