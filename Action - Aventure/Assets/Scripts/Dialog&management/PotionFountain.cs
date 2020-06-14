using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
	public class PotionFountain : MonoBehaviour
	{
        #region Variables
        private bool playerHere = false;
        #endregion

        private void Update()
        {
            if(playerHere == true)
            {
                PlayerManager.Instance.potionBottles.nearFountain = true;

                if (Input.GetButtonDown("A_Button"))
                {
                    playerHere = false;
                }
            }

            if (playerHere == false)
            {
                PlayerManager.Instance.potionBottles.nearFountain = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "PlayerController")
            {
                playerHere = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "PlayerController")
            {
                playerHere = false;

            }
        }
    }
}

