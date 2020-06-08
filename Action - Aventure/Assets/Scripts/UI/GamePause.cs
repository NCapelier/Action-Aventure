using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start_Button") && GameManager.Instance.gameState.inPause == true)
        {

            EnterInPauseMenu();
            GameManager.Instance.gameState.inPause = false;

        }
        else if (Input.GetButtonDown("Start_Button") && GameManager.Instance.gameState.inPause == false)
        {
            LeavingPauseMenu();
            GameManager.Instance.gameState.inPause = true;

        }



    }

    void EnterInPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    void LeavingPauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
