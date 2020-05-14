using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lantern;

public class LightCanvasManager : MonoBehaviour
{
    /// <summary>
    /// Script managing the LanternState in UI.
    /// </summary>

    [SerializeField]
    private Image lanternIsLit;
    [SerializeField]
    private Image lanternNotlit;

    // Start is called before the first frame update
    void Start()
    {
        lanternIsLit.enabled = true;
        lanternNotlit.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(LanternManager.Instance.hideLight.currentLightState == lightState.Displayed)
        {
            lanternIsLit.enabled = true;
            lanternNotlit.enabled = false;
        }
        else if (LanternManager.Instance.hideLight.currentLightState == lightState.Hidden)
        {
            lanternIsLit.enabled = false;
            lanternNotlit.enabled = true;
        }
    }
}
