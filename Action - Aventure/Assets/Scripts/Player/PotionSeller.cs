using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
	public class PotionSeller : MonoBehaviour
	{
        #region Variables
        [SerializeField] int[] potionStepCost;
        int currentStep = 0;

        bool playerNear;
        #endregion

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "PlayerController")
            {
                playerNear = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "PlayerController")
            {
                playerNear = false;
            }
        }

        // Update is called once per frame
        void Update()
		{

            if (GameManager.Instance.gameState.potionGet && playerNear)
            {
                if (Input.GetButtonDown("A_Button"))
                {
                    BuyPotion();
                }
            }

            //Comment out when testing done
            if (Input.GetKeyDown(KeyCode.C))
            {
                CheatSouls();
            }
		}

        void BuyPotion()
        {
            if (GoldTextScript.coinAmount >= potionStepCost[currentStep] && currentStep < 3)
            {
                PotionsTextScript.maxPotionAmount++;
                PotionsTextScript.potionAmount++;

                GoldTextScript.coinAmount -= potionStepCost[currentStep];
                currentStep++;
            }
            else if (currentStep >= 3)
            {
            }
            else if (GoldTextScript.coinAmount < potionStepCost[currentStep])
            {
            }
        }

        void CheatSouls()
        {
            GoldTextScript.coinAmount += 400;
        }

	}
}

