using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Player;

public class BlockerCaravane : MonoBehaviour
{
    /// <summary>
    /// XP - This script block the player if he don't have the lantern yet.
    /// </summary>*
 
    public Dialog.Conversation canPassThrought;

    private void Start()
    {
        GetComponent<SceneTransition>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Instance.GetComponent<GameState>().lanternGet == false)
        {
            PlayerManager.Instance.controller.isDialoging = true;

            GameCanvasManager.Instance.dialog.StartDialog = canPassThrought;

            PlayerManager.Instance.controller.isDialoging = true;
        }
        else
        {
            GetComponent<SceneTransition>().enabled = true;
        }
    }



}
