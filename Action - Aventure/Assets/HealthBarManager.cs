using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.UI;


public class HealthBarManager : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //passer current HP en Float car fill amout [0;1]
        healthBar.fillAmount = (float)PlayerManager.Instance.currentHp / (float)PlayerManager.Instance.currentMaxHp;
    }
}
