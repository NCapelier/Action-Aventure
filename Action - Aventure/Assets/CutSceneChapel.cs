using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using GameManagement;
using Player;


public class CutSceneChapel : MonoBehaviour
{
    private PlayableDirector timeline;

    private BoxCollider2D boxCol;

    private bool startTimeline;
    [SerializeField] private float timeTimeline;

    private bool finished;

    private Camera stokageCamera;

    [SerializeField] GameObject cutSceneCamera;

    private void Start()
    {
        StartCoroutine("StartT");
    }

    private void Update()
    {
        if (startTimeline == true)
        {
            timeTimeline += 1;
        }

        if(timeTimeline == 800)
        {
            timeline.Stop();
            cutSceneCamera.SetActive(false);
            stokageCamera.enabled = true;
            PlayerManager.Instance.controller.isDialoging = false;
        }
    }


    IEnumerator StartT()
    {
        finished = false;
        boxCol = GetComponent<BoxCollider2D>();
        timeline = GetComponent<PlayableDirector>();

        startTimeline = true;

        stokageCamera = Camera.main;
        stokageCamera.enabled = false;
        cutSceneCamera.SetActive(true);
        PlayerManager.Instance.controller.isDialoging = true;

        yield return null;
    }
   
}
