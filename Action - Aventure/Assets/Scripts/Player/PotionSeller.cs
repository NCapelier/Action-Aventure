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
        public int currentStep = 0;

        [SerializeField] private bool playerNear;
        


        [SerializeField] private Dialog.Conversation needMoreSouls1;
        [SerializeField] private Dialog.Conversation needMoreSouls2;
        [SerializeField] private Dialog.Conversation needMoreSouls3;
        [SerializeField] private Dialog.Conversation noMorePotions;
        [SerializeField] private Dialog.Conversation potionObtenu;
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
            if (GameManager.Instance.gameState.potionGet && playerNear ==true)
            {
                if (Input.GetButtonDown("A_Button"))
                {
                    BuyPotion();
                    playerNear = false;
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
            if (currentStep == 3)
            {
                GameCanvasManager.Instance.dialog.StartDialog = noMorePotions;
            }
            else if (GoldTextScript.coinAmount >= potionStepCost[currentStep] && currentStep < 3)
            {
                GameCanvasManager.Instance.dialog.StartDialog = potionObtenu;
                PotionsTextScript.maxPotionAmount++;
                PotionsTextScript.potionAmount++;

                GoldTextScript.coinAmount -= potionStepCost[currentStep];
                currentStep++;
                
            }
          
            else if (GoldTextScript.coinAmount < potionStepCost[0] && currentStep == 0)
            {

                GameCanvasManager.Instance.dialog.StartDialog = needMoreSouls1;

            }
            else if (GoldTextScript.coinAmount < potionStepCost[1] && currentStep == 1)
            {

                GameCanvasManager.Instance.dialog.StartDialog = needMoreSouls2;

            }
            else if (GoldTextScript.coinAmount < potionStepCost[2] && currentStep == 2)
            {

                GameCanvasManager.Instance.dialog.StartDialog = needMoreSouls3;

            }



        }

        void CheatSouls()
        {
            GoldTextScript.coinAmount += 400;
        }

	}
}

