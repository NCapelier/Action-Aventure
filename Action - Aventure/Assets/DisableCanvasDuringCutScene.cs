using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class DisableCanvasDuringCutScene : MonoBehaviour
{
    public GameObject allCanvas;

    // Update is called once per frame
    void Update()
    {
        if(GameCanvasManager.Instance.dialog.isCutScene == true || GameManager.Instance.gameState.gameFinished== true)
        {
            allCanvas.SetActive(false);
        }
        else
        {
            allCanvas.SetActive(true);
        }
    }
}
