using System.Collections;
using UnityEngine;
using Boss;
using GameManagement;
using UnityEngine.UI;

public class TriggerCutSceneBoss2 : MonoBehaviour
{
    [SerializeField] private Dialog.Conversation dial;
    [SerializeField] private Image bossUI;

    void Update()
    {
        if(BossManager.Instance.controller.currentBossState == bossState.CutScene2)
        {
            bossUI.enabled = false;
            GameCanvasManager.Instance.dialog.isCutScene = true;
            GameCanvasManager.Instance.dialog.StartDialog = dial;

                StartCoroutine("Delay");

            
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
        BossManager.Instance.controller.currentBossState = bossState.Phase2;
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        bossUI.enabled = true;
    }
}
