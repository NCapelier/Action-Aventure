using System.Collections;
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
        [HideInInspector] public bool inDrinkUnhideMalus = false;
        [SerializeField] private Dialog.Conversation refillPotion;
        [SerializeField] private Dialog.Conversation stockFull;

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
            //Debug.Log("Player near a fountain: " + nearFountain);
            //Debug.Log("Nb of potions: " + PotionsTextScript.potionAmount + " out of " + PotionsTextScript.maxPotionAmount);

            if (GameManager.Instance.gameState.potionGet)
            {
                PotionDrink();

                if (nearFountain)
                {
                    
                    PotionRefill();
                }
            }

            //Debug.Log(LanternManager.Instance.hideLight.currentLightState);
        }

        void PotionDrink()
        {
            if (PotionsTextScript.potionAmount > 0 && Input.GetButtonDown("Y_Button"))
            {
                //PlayerManager.Instance.currentMaxHp = PlayerManager.Instance.maxHp;
                PlayerManager.Instance.Heal = 6;

                StartCoroutine(DrinkUnhide());
                //if (LanternManager.Instance.hideLight.currentLightState == lightState.Hidden)
                //{
                //    StartCoroutine(DrinkUnhide());
                //}

                //Play FX

                //Sound
                AudioManager.Instance.Play("Potion_drink");

                PotionsTextScript.potionAmount--;
            }
        }

        void PotionRefill()
        {
            if(PotionsTextScript.potionAmount == PotionsTextScript.maxPotionAmount && Input.GetButtonDown("A_Button"))
            {
                GameCanvasManager.Instance.dialog.StartDialog = stockFull;
            }

            else if(PotionsTextScript.potionAmount < PotionsTextScript.maxPotionAmount && Input.GetButtonDown("A_Button"))
            {
                GameCanvasManager.Instance.dialog.StartDialog = refillPotion;
                PotionsTextScript.potionAmount += PotionsTextScript.maxPotionAmount - PotionsTextScript.potionAmount;
                AudioManager.Instance.Play("Potion_refill");
                
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

