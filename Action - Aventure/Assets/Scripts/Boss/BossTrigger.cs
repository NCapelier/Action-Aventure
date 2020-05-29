using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    /// <summary>
    /// NCO
    /// </summary>
    public class BossTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Wall"))
            {
                if(BossManager.Instance.controller.currentBossState == bossState.Phase1)
                {
                    BossManager.Instance.controller.stopDash = true;
                }
                else if(BossManager.Instance.controller.currentBossState == bossState.Phase2)
                {

                }
            }
            if(collision.CompareTag("Rock") && BossManager.Instance.controller.currentBossState == bossState.Phase2)
            {
                BossManager.Instance.controller.touchedRock = true;
            }
        }
    }
}