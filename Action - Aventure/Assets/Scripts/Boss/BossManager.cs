using UnityEngine;
using Management;
using Player;

namespace Boss
{

    public enum bossState { CutScene1, Phase1, CutScene2, Phase2, CutScene3};

    /// <summary>
    /// NCO
    /// </summary>
    public class BossManager : Singleton<BossManager>
    {
        #region Variables

        [Header("Refs")]
        public BossController controller = null;

        [Header("Variables")]
        [Range(0, 50)]
        public float hp = 20f;
        public int maxHp = 20;
        #endregion

        #region Properties

        public int TakeDamages
        {
            get
            {
                return (int)hp;
            }
            set
            {
                if(controller.currentBossState == bossState.Phase1)
                {
                    controller.animator.SetBool("isHit", true);
                    controller.headBandCount--;
                    controller.StopCoroutine(controller.routine);
                    controller.isWeak = false;
                    controller.animator.SetBool("isWeak", false);
                }
                else if(controller.currentBossState == bossState.Phase2 && controller.touchedRock)
                {
                    controller.animator.SetBool("isHit", true);

                    RockManager.Instance.DestroyRocks();

                    hp -= value;

                    if (hp <= 0)
                    {
                        Death();
                    }
                }
            }
        }

        #endregion

        private void Awake()
        {
            MakeSingleton(false);
        }

        void Death()
        {
            controller.currentBossState = bossState.CutScene3;
           
        }

    }
}