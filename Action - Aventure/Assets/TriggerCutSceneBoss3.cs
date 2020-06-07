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

    //Timer CutScene
    private PlayableDirector timeline;
    [SerializeField] private float timerClip = 0f;
    private bool starTimer = false;
    private bool needToUpdate = false;

    private bool isTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BossManager.Instance.controller.currentBossState == bossState.CutScene3)
        {
            isTrigger = true;
        }

        if(isTrigger == true)
        {
            if (starTimer == true)
            {
                StartCoroutine("UpdateTimer");
            }

            if (starTimer == true)
            {
                starTimer = false;
                StartCoroutine("Dialog");
            }

            /*if (timerClip >= //LaFin)
            {
                needToUpdate = false;
            }*/
        }

    }

    IEnumerator UpdateTimer()
    {
        timerClip++;
        needToUpdate = true;

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
        timeline.Play();
        //Fade
        PlayerManager.Instance.transform.position = waypointsJoueur.transform.position;
        BossManager.Instance.transform.position = waypointsBoss.transform.position;
        //GameCanvasManager.Instance.dialog.StartDialog = dial1;
        yield return null;
       

    }
}
