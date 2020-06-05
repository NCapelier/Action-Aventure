using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Boss;

public class UIBOSS : MonoBehaviour
{

    [SerializeField]
    private Image bossHealthBar;

    public GameObject bossBandeau1;

    public GameObject bossBandeau2;

    public GameObject bossBandeau3;

    [SerializeField] private GameObject allObjects;

    


    // Update is called once per frame
    void Update()
    {
      bossHealthBar.fillAmount = (float)BossManager.Instance.hp /(float)BossManager.Instance.maxHp;

        if (BossManager.Instance.controller.currentBossState == bossState.CutScene1)
        {
            bossHealthBar.enabled = false;
            bossBandeau1.SetActive(false);
            bossBandeau2.SetActive(false);
            bossBandeau3.SetActive(false);
        }

       else if (BossManager.Instance.controller.currentBossState == bossState.Phase1)
        {
            if (BossManager.Instance.controller.headBandCount == 3)
            {
                bossHealthBar.enabled = true;
                bossBandeau1.SetActive(true);
                bossBandeau2.SetActive(true);
                bossBandeau3.SetActive(true);
            }

            if (BossManager.Instance.controller.headBandCount == 2)
            {
                bossBandeau3.SetActive(false);
            }
            if (BossManager.Instance.controller.headBandCount == 1)
            {
                bossBandeau2.SetActive(false);
            }
            if (BossManager.Instance.controller.headBandCount == 0)
            {
                bossBandeau1.SetActive(false);
            }
        }

        else if (BossManager.Instance.controller.currentBossState == bossState.CutScene2)
        {
            bossHealthBar.enabled = false;
           
        }

        else if (BossManager.Instance.controller.currentBossState == bossState.Phase2)
        {
            bossHealthBar.enabled = true;
        }


        else if (BossManager.Instance.controller.currentBossState == bossState.CutScene3)
        {
            bossHealthBar.enabled = false;
            bossBandeau1.SetActive(false);
            bossBandeau2.SetActive(false);
            bossBandeau3.SetActive(false);
        }





    }
}
