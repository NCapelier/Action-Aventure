﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Lantern;
using GameSound;

namespace Player
{
    /// <summary>
    /// CHB -- Manages potion drink and refill
    /// </summary>
    public class PotionBottles : MonoBehaviour
	{
        #region Variables
        [HideInInspector] public bool nearFountain;
        bool inDrinkUnhideMalus = false;
		#endregion

		// Start is called before the first frame update
		void Start()
		{
            nearFountain = false;

            //Comment this out when testing done
            //PotionsTextScript.maxPotionAmount = 1;
            //PotionsTextScript.potionAmount = 1;

        }

		// Update is called once per frame
		void Update()
		{

            if (GameManager.Instance.gameState.potionGet)
            {
                PotionDrink();

                if (nearFountain)
                {
                    PotionRefill();
                }
            }

		}

        void PotionDrink()
        {
            if (PotionsTextScript.potionAmount > 0 && Input.GetButtonDown("Y_Button"))
            {
                PlayerManager.Instance.currentMaxHp = PlayerManager.Instance.maxHp;
                PlayerManager.Instance.Heal = PlayerManager.Instance.maxHp - PlayerManager.Instance.currentHp;

                StartCoroutine(DrinkUnhide());
                //if (LanternManager.Instance.hideLight.currentLightState == lightState.Hidden)
                //{
                //    StartCoroutine(DrinkUnhide());
                //}

                //Play FX

                //Sound
                AudioManager.Instance.Play("Will_o_flight");

                PotionsTextScript.potionAmount--;
            }
        }

        void PotionRefill()
        {
            if(PotionsTextScript.potionAmount < PotionsTextScript.maxPotionAmount && Input.GetButtonDown("A_Button"))
            {
                PotionsTextScript.potionAmount += PotionsTextScript.maxPotionAmount - PotionsTextScript.potionAmount;
            }
        }
        
        //Can't work atm, need to make playerCrazy public and remove currentLightState == Hidden in EndHide() launch condition 
        IEnumerator DrinkUnhide()
        {
            LanternManager.Instance.hideLight.currentLightState = lightState.Displayed;

            inDrinkUnhideMalus = true;
            StartCoroutine(DrinkUnhideMalus());

            yield return new WaitForSeconds(1.5f);

            StopCoroutine(DrinkUnhideMalus());
            inDrinkUnhideMalus = false;

            if (LanternManager.Instance.hideLight.playerCrazy)
            {
                LanternManager.Instance.hideLight.currentLightState = lightState.Hidden;
            }
        }

        IEnumerator DrinkUnhideMalus()
        {
            while (inDrinkUnhideMalus)
            {
                yield return new WaitUntil(() => LanternManager.Instance.hideLight.currentLightState == lightState.Hidden);
                LanternManager.Instance.hideLight.currentLightState = lightState.Displayed;
            }
        }
    }
}
