using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Lantern;

namespace Player
{
	public class PotionBottles : MonoBehaviour
	{
        #region Variables
        [HideInInspector] public bool nearFountain;
		#endregion

		// Start is called before the first frame update
		void Start()
		{
            nearFountain = false;
            PotionsTextScript.maxPotionAmount = 3;
            PotionsTextScript.potionAmount = 1;

        }

		// Update is called once per frame
		void Update()
		{
            Debug.Log("Player near a fountain: " + nearFountain);
            Debug.Log("Nb of potions: " + PotionsTextScript.potionAmount + " out of " + PotionsTextScript.maxPotionAmount);
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

                if (LanternManager.Instance.hideLight.currentLightState == lightState.Hidden)
                {
                    StartCoroutine(DrinkUnhide());
                }

                //Play FX

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

            yield return new WaitForSeconds(1.5f);

            if (LanternManager.Instance.hideLight.playerCrazy)
            {
                LanternManager.Instance.hideLight.currentLightState = lightState.Hidden;
            }
        }
    }
}

