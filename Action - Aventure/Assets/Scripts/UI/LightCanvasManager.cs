using UnityEngine;
using UnityEngine.UI;
using Lantern;
using GameManagement;

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
        else if (LanternManager.Instance.hideLight.currentLightState == lightState.Hidden || GameManager.Instance.GetComponent<GameState>().lanternGet == false)
        {
            lanternIsLit.enabled = false;
            lanternNotlit.enabled = true;
        }
    }
}
