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

    


    // Update is called once per frame
    void Update()
    {
      bossHealthBar.fillAmount = (float)BossManager.Instance.hp /(float)BossManager.Instance.maxHp;


        if(BossManager.Instance.controller.headBandCount == 3)
        {
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
}
