using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
	public class PotionFountain : MonoBehaviour
	{
        #region Variables
        
        #endregion

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "PlayerController")
            {
                PlayerManager.Instance.potionBottles.nearFountain = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "PlayerController")
            {
                PlayerManager.Instance.potionBottles.nearFountain = false;

            }
        }
    }
}

