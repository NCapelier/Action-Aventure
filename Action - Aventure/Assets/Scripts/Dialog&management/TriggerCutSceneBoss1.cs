using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using UnityEngine.Playables;
using Player;
using Boss;
using GameSound;

public class TriggerCutSceneBoss1 : MonoBehaviour
{/// <summary>
 /// XP : Reference for CutSceneBoss1
 /// </summary>

    //Game Object reference
    [SerializeField] private GameObject grille;
    [SerializeField] private Dialog.Conversation dial1;
    [SerializeField] private GameObject willOCS;
    [SerializeField] private GameObject whiteScreen;

    //Timer CutScene
    private PlayableDirector timeline;
    [SerializeField] private float timerClip = 0f;
    private bool starTimer = false;
    private bool needToUpdate = false;

    //things need to disabled
    private BoxCollider2D boxCol;

    private void Start()
    {

        timeline = GetComponent<PlayableDirector>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(starTimer == true)
        {

            StartCoroutine("UpdateTimer");
            
        }

        if(starTimer == true)
        {
            starTimer = false;
            StartCoroutine("Dialog");
        }

        if(timerClip >= 700)
        {
            needToUpdate = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Quand le player rentre dans la zone de collision, la cut scene se lance. Dial passe automatiquement.
        if (collision.gameObject.tag == "PlayerController")
        {
     
            PlayerManager.Instance.controller.isDialoging = true;
            
            starTimer = true;
        }
    }

    IEnumerator UpdateTimer()
    {
        timerClip++;
        needToUpdate = true;

        if (timerClip >= 700)
        {
            needToUpdate = false;
        }
        if (needToUpdate == true)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine("UpdateTimer");
        }
        
    }

   IEnumerator Dialog()
    {
        starTimer = false;
        GameCanvasManager.Instance.dialog.isCutScene = true;
        GameCanvasManager.Instance.dialog.StartDialog = dial1;
        timeline.Play();
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(1f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        AudioManager.Instance.PlayMusic(MusicID.BossBattle);
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(2f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        timeline.Stop();
        yield return new WaitForSeconds(2f);
        willOCS.SetActive(false);
        BossManager.Instance.controller.currentBossState = bossState.Phase1;
        gameObject.SetActive(false);
       
    }

}
