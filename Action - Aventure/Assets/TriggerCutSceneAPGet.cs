using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using GameManagement;

public class TriggerCutSceneAPGet : MonoBehaviour
{

    private PlayableDirector timeline;

    [SerializeField] GameObject whiteScreen;

    [SerializeField] private Dialog.Conversation dial1;

    private BoxCollider2D boxCol;

    private bool startTimeline;
    private float timeTimeline;

    private bool finished;
    // Start is called before the first frame update
    void Start()
    {
        whiteScreen.GetComponent<SpriteRenderer>().enabled = false;

        finished = false;
        whiteScreen.SetActive(false);

        boxCol = GetComponent<BoxCollider2D>();
        timeline = GetComponent<PlayableDirector>();
    }
    private void Update()
    {
        if (startTimeline == true)
        {
            timeTimeline += 1;
        }

        if (GameManager.Instance.GetComponent<GameState>().versatileGet == true)
        {
            boxCol.enabled = true;
        }
        if(finished == true)
        {
            boxCol.enabled = false;
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="PlayerController")
        {
            if (GameManager.Instance.GetComponent<GameState>().CutsceneFlash == false && finished == false)
            {
                Debug.Log("trigger");
                StartCoroutine("CutScene");
            }
           

        }
    }

    IEnumerator CutScene()
    {
        GameCanvasManager.Instance.dialog.isCutScene = true;
        GameCanvasManager.Instance.dialog.StartDialog = dial1;
        yield return new WaitForSeconds(3);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        timeline.Play();
        whiteScreen.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        whiteScreen.GetComponent<SpriteRenderer>().enabled = false;
        timeline.Stop();
        
   
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;

        GameManager.Instance.GetComponent<GameState>().needToShow = true;

        finished = true;

        GameManager.Instance.GetComponent<GameState>().CutsceneFlash = false;
    }

}
