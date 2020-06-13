using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lantern;
using UnityEngine.UI;

public class UILantern : MonoBehaviour
{

    [SerializeField]
    private Image lanternBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lanternBar.fillAmount = LanternManager.Instance.hideLight.displayTime;
    }
}
