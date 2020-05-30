using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Boss;

public class UIBOSS : MonoBehaviour
{

    [SerializeField]
    private Image bossHealthBar;
   

    // Update is called once per frame
    void Update()
    {
        bossHealthBar.fillAmount = (float)BossManager.Instance.hp /(float)BossManager.Instance.maxHp;
    }
}
