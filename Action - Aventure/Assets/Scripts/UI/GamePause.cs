using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using GameSound;
using Player;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start_Button") && GameManager.Instance.gameState.inPause == false)
        {

            EnterInPauseMenu();
            GameManager.Instance.gameState.inPause = true;
            AudioManager.Instance.Play("Pause_sound");
        }
        else if (Input.GetButtonDown("Start_Button") && GameManager.Instance.gameState.inPause == true)
        {
            LeavingPauseMenu();
            GameManager.Instance.gameState.inPause = false;

        }



    }

    void EnterInPauseMenu()
    {
        pauseMenu.SetActive(true);
        PlayerManager.Instance.controller.isDialoging = true;
        Time.timeScale = 0;
        AudioManager.Instance.TooglePauseLoops(true);
    }

    void LeavingPauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioManager.Instance.TooglePauseLoops(false);
        PlayerManager.Instance.controller.isDialoging = false;
    }
}
