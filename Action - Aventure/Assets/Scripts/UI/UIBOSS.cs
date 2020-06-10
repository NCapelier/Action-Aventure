using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Boss;

public class UIBOSS : MonoBehaviour
{

    [SerializeField]
    private Image bossHealthBar;

    [SerializeField] private GameObject backHealth;

    [SerializeField] private GameObject bossBandeau1;

    [SerializeField] private GameObject bossBandeau2;

    [SerializeField] private GameObject bossBandeau3;



    [SerializeField] private Color stockColor;

    private void Start()
    {
        stockColor = bossHealthBar.color;
    }

    void Update()
    {
      bossHealthBar.fillAmount = (float)BossManager.Instance.hp /(float)BossManager.Instance.maxHp;

       if(BossManager.Instance.controller.currentBossState == bossState.Phase2 && BossManager.Instance.controller.isWeak == true)
       {
            bossHealthBar.color = Color.red;
       }
        else
        {
            bossHealthBar.color = stockColor;
        }

        

        if (BossManager.Instance.controller.currentBossState == bossState.CutScene1)
        {
            backHealth.SetActive(false);
            bossHealthBar.enabled = false;
            bossBandeau1.SetActive(false);
            bossBandeau2.SetActive(false);
            bossBandeau3.SetActive(false);
        }
        if (BossManager.Instance.controller.currentBossState == bossState.CutScene2)
        {
            backHealth.SetActive(false);
            bossHealthBar.enabled = false;
            bossBandeau1.SetActive(false);
            bossBandeau2.SetActive(false);
            bossBandeau3.SetActive(false);
        }

        else if (BossManager.Instance.controller.currentBossState == bossState.Phase1)
        {
            if (BossManager.Instance.controller.headBandCount == 3)
            {
                backHealth.SetActive(true);
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
            backHealth.SetActive(false);

        }

        else if (BossManager.Instance.controller.currentBossState == bossState.Phase2)
        {
            backHealth.SetActive(true);
            bossHealthBar.enabled = true;

        }


        else if (BossManager.Instance.controller.currentBossState == bossState.CutScene3)
        {
            backHealth.SetActive(false);
            bossHealthBar.enabled = false;
            bossBandeau1.SetActive(false);
            bossBandeau2.SetActive(false);
            bossBandeau3.SetActive(false);
        }





    }
}
