using System.Collections;
using UnityEngine;
using GameManagement;
using Player;
using UnityEngine.Playables;

public class EntréeMaison : MonoBehaviour
{
    [SerializeField] public Dialog.Conversation entréeMaison;
    [SerializeField] public Dialog.Conversation arrivéeMaman;

    [SerializeField] private GameObject enemyEyes;
    [SerializeField] private GameObject enemySkin;


    public GameObject enemy;
    [SerializeField] private Animator enemyEye;
    [SerializeField] private Animator enemyskin;

    [SerializeField] private BoxCollider2D boxCol;

    private PlayableDirector timeline;
    private bool timelineF = false;
    private bool playerDial = false;

    private Camera stokageCamera;

    [SerializeField] private GameObject cutSceneCamera;

    private void Awake()
    {
        if (GameManager.Instance.gameState.cutSCaveDone == true)
        {
            timeline.enabled = false;
        }

        
    }

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        boxCol = GetComponent<BoxCollider2D>();

        
    }

private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController")
        {

            if(GameManager.Instance.gameState.cutSCaveDone == false)
            {
                StartCoroutine("CutScene");
            }
            
            

        }   
    }

    private void Update()
    {
        if(playerDial == true)
        {
            PlayerManager.Instance.controller.isDialoging = true;
        }

        if (timelineF == true)
        {
            //Eye skin
          
            //Anim skin
            timeline.Stop();
            cutSceneCamera.SetActive(false);
            stokageCamera.enabled = true;
        }
    }

    IEnumerator CutScene()
    {
        timeline.Play();
        stokageCamera = Camera.main;
        stokageCamera.enabled = false;
        cutSceneCamera.SetActive(true);


        GameCanvasManager.Instance.dialog.isCutScene = true;
        yield return new WaitForSeconds(0.1f);
        GameCanvasManager.Instance.dialog.StartDialog = entréeMaison;
        yield return new WaitForSeconds(3.2f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3.2f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        playerDial = true;
        yield return new WaitForSeconds(3.2f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        PlayerManager.Instance.controller.isDialoging = true;
        yield return new WaitForSeconds(2f);
       
        GameCanvasManager.Instance.dialog.isCutScene = true;
        yield return new WaitForSeconds(0.1f);
        GameCanvasManager.Instance.dialog.StartDialog = arrivéeMaman;
        yield return new WaitForSeconds(2f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(2f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        PlayerManager.Instance.controller.isDialoging = false;
        playerDial = false;

        //timeline.Stop();
        GameManager.Instance.GetComponent<GameState>().versatileGet = true;
        timelineF = true;
       

        boxCol.enabled = false;
        
        
        GameManager.Instance.gameState.cutSCaveDone = true;
    }
}
