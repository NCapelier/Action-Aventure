using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using GameManagement;
using Player;

public class CutSceneForet2 : MonoBehaviour
{
  
    [SerializeField] private PlayableDirector timeline;

    private BoxCollider2D boxCol;

    private bool startTimeline;
    [SerializeField] private float timeTimeline;


    private bool finished;

    public Camera stokageCamera;

    [SerializeField] private GameObject door;
    [SerializeField] private GameObject door1;

    [SerializeField] private GameObject cutSceneCamera;
    // Start is called before the first frame update

    private void Awake()
    {
        timeline = gameObject.GetComponent<PlayableDirector>();
        door.GetComponent<Animator>().enabled = false;

        finished = false;
        cutSceneCamera.SetActive(false);

       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController") && GameManager.Instance.gameState.cutSForet2 == false)
        {
            StartCoroutine("StartT");
           
            Debug.Log("Called");
            door1.SetActive(false);
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        if (startTimeline == true)
        {
            timeTimeline += 1;
        }
        
        if(timeTimeline >= 230)
        {
            door.GetComponent<Animator>().enabled = true;
        }

            if (timeTimeline >= 1300)
            {
                startTimeline = false;
                
                

                
                Debug.Log("Called");
                door1.SetActive(true);
                door.SetActive(false);
                timeline.Stop();
               
                


            

            cutSceneCamera.SetActive(false);
            stokageCamera.enabled = true;
            Destroy(door);

            GameManager.Instance.gameState.cutSForet2 = true;
            PlayerManager.Instance.controller.isDialoging = false;
        }
        
       
       
    }
    IEnumerator StartT()
    {
        PlayerManager.Instance.controller.isDialoging = true;
        timeline.Play();
        startTimeline = true;
        stokageCamera = Camera.main;
        stokageCamera.enabled = false;

        cutSceneCamera.SetActive(true);

        

        yield return null;
    }
}
