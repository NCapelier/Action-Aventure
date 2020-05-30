using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.Video;

public class VideoIntro : MonoBehaviour
{
    [SerializeField] private GameObject gameCanvas;
    private bool startTimer = false;
    public int videoTime;
    [SerializeField] private VideoPlayer videoPlayer;

    private void Awake()
    {
        gameCanvas.SetActive(false);

        startTimer = true;

        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState.videoIntroDone == false)
        {
            PlayerManager.Instance.controller.isDialoging = true;

            
        }

        if(videoTime >= 105)
        {
            GameManager.Instance.gameState.videoIntroDone = true;
            videoPlayer.Stop();
            PlayerManager.Instance.controller.isDialoging = false;

            gameCanvas.SetActive(true);
        }

        if(startTimer == true)
        {
            startTimer = false;
            StartCoroutine("Timer");
            
        }
                
    }

    IEnumerator Timer()
    {
        videoTime++;

        yield return new WaitForSeconds(0.5f);
        if(GameManager.Instance.gameState.videoIntroDone == false)
        {
            StartCoroutine("Timer");
        }
      
    }
    
}
