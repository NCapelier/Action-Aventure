using UnityEngine;
using Enemy;
using GameManagement;
using Boss;

namespace Lantern
{
    /// <summary>
    /// NCO - Manages the lantern's collider
    /// </summary>
    public class LanternInteractions : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag("Enemy") && LanternManager.Instance.boomerang.currentBoomerangState != boomerangState.Tidy
                && GameManager.Instance.gameState.versatileGet)
            {

                if(collision.gameObject.GetComponent<EnemyParent>())
                {
                    //deal damages to the enemy
                    collision.GetComponent<EnemyParent>().TakeDamages = 1;
                }

                if(LanternManager.Instance.flashLight.currentFlashState == flashState.FlashingUp || LanternManager.Instance.flashLight.currentFlashState == flashState.FlashingDown)
                {
                    //stuns the enemy
                }
            }

            if (collision.gameObject.CompareTag("TorchTag") && LanternManager.Instance.flashLight.currentLightStrength == lightStrength.Recovering)
            {
                LanternManager.Instance.flashLight.mustRegerenate = true;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Wall") && LanternManager.Instance.boomerang.currentBoomerangState == boomerangState.Cast)
            {
                LanternManager.Instance.boomerang.mustStop = true;
            }
            if (collision.CompareTag("BossTrigger") && (LanternManager.Instance.flashLight.currentFlashState == flashState.FlashingUp || LanternManager.Instance.flashLight.currentFlashState == flashState.FlashingDown))
            {
                BossManager.Instance.TakeDamages = 3;
            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.CompareTag("TorchTag"))
            {
                LanternManager.Instance.flashLight.mustRegerenate = false;
            }
        }

    }
}