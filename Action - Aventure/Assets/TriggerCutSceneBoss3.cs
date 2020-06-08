using UnityEngine;
using System.Collections;
using GameManagement;
using UnityEngine.Playables;
using Player;
using Boss;

public class TriggerCutSceneBoss3 : MonoBehaviour
{
    //waypoints
    [SerializeField] private GameObject waypointsBoss;
    [SerializeField] private GameObject waypointsJoueur;

    [SerializeField] private Dialog.Conversation dial1;
    [SerializeField] private Dialog.Conversation dial2;

    //Timer CutScene
    private PlayableDirector timeline;
    [SerializeField] private float timerClip = 0f;
    [SerializeField] private bool starTimer = false;
    private bool needToUpdate = false;

    [SerializeField] private bool isTrigger = false;
    [SerializeField] private bool dial1Finish = false;

    // Start is called before the first frame update
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        dial1Finish = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(BossManager.Instance.controller.currentBossState == bossState.CutScene3 && starTimer == false)
        {
            isTrigger = true;
        }

        if(isTrigger == true)
        {
            if(starTimer == false)
            {
                StartCoroutine("UpdateTimer");
            }
           
            if(starTimer == false)
            {
                StartCoroutine("Dialog");
            }
            
            

            /*if (timerClip >= //LaFin)
            {
                needToUpdate = false;
            }*/
        }
        if(dial1Finish == true)
        {
            StartCoroutine("Dialog2");
        }

    }

    IEnumerator UpdateTimer()
    {
        timerClip +=1;
        needToUpdate = true;

        if (needToUpdate == true)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine("UpdateTimer");
        }

    }

    IEnumerator Dialog()
    {
        starTimer = true;
  
        timeline.Play();
        PlayerManager.Instance.transform.position = waypointsJoueur.transform.position;
        BossManager.Instance.transform.position = waypointsBoss.transform.position;
        yield return new WaitForSeconds(1f);
        GameCanvasManager.Instance.dialog.isCutScene = true;
        GameCanvasManager.Instance.dialog.StartDialog = dial1;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(1f);
        Debug.Log("FinDial1");
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        dial1Finish = true;

    }

    IEnumerator Dialog2()
    {   
            dial1Finish = false;
            Debug.Log("StartDial2");
            GameCanvasManager.Instance.dialog.isCutScene = true;
            GameCanvasManager.Instance.dialog.StartDialog = dial2;
            yield return new WaitForSeconds(3f);
            GameCanvasManager.Instance.dialog.forceUpdate = true;
            yield return new WaitForSeconds(3f);
            GameCanvasManager.Instance.dialog.forceUpdate = true;
            yield return new WaitForSeconds(3f);
            GameCanvasManager.Instance.dialog.forceUpdate = true;
            yield return new WaitForSeconds(3f);
            GameCanvasManager.Instance.dialog.forceUpdate = true;
          
       
    }
}
