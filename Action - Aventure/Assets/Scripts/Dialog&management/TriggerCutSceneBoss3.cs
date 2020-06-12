using UnityEngine;
using System.Collections;
using GameManagement;
using UnityEngine.Playables;
using Player;
using Boss;
using Management;
using UnityEngine.SceneManagement;

public class TriggerCutSceneBoss3 : MonoBehaviour
{
    //Scene Transiton
   

    //waypoints
    [SerializeField] private GameObject waypointsBoss;
    [SerializeField] private GameObject waypointsJoueur;

    [SerializeField] private Dialog.Conversation dial1;
    [SerializeField] private Dialog.Conversation dial2;
    [SerializeField] private Dialog.Conversation dial3;
    //Halo
    [SerializeField] private GameObject wCircle;
    [SerializeField] private SpriteRenderer circleRenderer;
    [SerializeField] private GameObject wCircle1;
    [SerializeField] private SpriteRenderer circleRenderer1;
    [SerializeField] private GameObject wCircle2;
    [SerializeField] private SpriteRenderer circleRenderer2;

    [SerializeField] private float timerUpdate;

    //Timer CutScene
    private PlayableDirector timeline;
    [SerializeField] private float timerClip = 0f;
    [SerializeField] private bool starTimer = false;
    private bool needToUpdate = false;

    [SerializeField] private bool isTrigger = false;
    [SerializeField] private bool dial1Finish = false;
    [SerializeField] private bool needToFlash = false;

    private bool dial2Finish = false;

    // Start is called before the first frame update
    void Start()
    {
        circleRenderer = wCircle.GetComponent<SpriteRenderer>();
        circleRenderer1 = wCircle1.GetComponent<SpriteRenderer>();
        circleRenderer2 = wCircle2.GetComponent<SpriteRenderer>();

        Color c = circleRenderer.material.color;
        c.a = 0f;
        circleRenderer.material.color = c;

        /*Color d = circleRenderer1.material.color;
        d.a = 0f;
        circleRenderer1.material.color = c;

        Color e = circleRenderer2.material.color;
        e.a = 0f;
        circleRenderer2.material.color = c;*/



        timeline = GetComponent<PlayableDirector>();
        dial1Finish = false;

        timerUpdate = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(BossManager.Instance.controller.currentBossState == bossState.CutScene3 && starTimer == false)
        {
            isTrigger = true;
            GameManager.Instance.gameState.gameFinished = true;
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

      if(dial2Finish == true)
        {
            StartCoroutine("Dialog3");
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
        GameCanvasManager.Instance.dialog.isCutScene = true;

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
        needToFlash = true;
        StartCoroutine("FadeIn");
       
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        //circleRenderer = wCircle2.GetComponent<SpriteRenderer>();
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(4f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;

        dial2Finish = true;
        
    }

    IEnumerator Dialog3()
    {
        dial2Finish = false;
        Debug.Log("StartDial3");
        GameCanvasManager.Instance.dialog.isCutScene = true;
        GameCanvasManager.Instance.dialog.StartDialog = dial3;
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
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(6f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        Debug.Log("Finish");
        timeline.Stop();

        SuperGameManager.Instance.DestroyAllGameObjects();
        SceneManager.LoadScene("SceneFinale");


    }

    IEnumerator FadeIn()
    {
        for (float f = 0.25f; f <= 1.1; f += 0.25f)
        {
            Color c = circleRenderer.material.color;
            c.a = f;
            circleRenderer.material.color = c;
            yield return new WaitForSeconds(timerUpdate);
        }

        yield return new WaitForSeconds(0.5f);
        StartCoroutine("FadeIn");

        
    }

    
    IEnumerator FadeIn1()
    {
        for (float x = 0.25f; x <= 1.1; x += 0.25f)
        {
            Color c= circleRenderer1.material.color;
            c.a = x;
            circleRenderer.material.color = c;
            yield return new WaitForSeconds(timerUpdate);
        }

        StartCoroutine("FadeIn1");
    }

   
    IEnumerator FadeIn2()
    {
        for (float y = 0.25f; y <= 1.1; y += 0.25f)
        {
            Color e = circleRenderer2.material.color;
            e.a = y;
            circleRenderer.material.color = e;
            yield return new WaitForSeconds(timerUpdate);
        }

        StartCoroutine("FadeIn2");

    }

   
}
