using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Dialog;
using Player;

public class EntréeMaison : MonoBehaviour
{
    [SerializeField] public Dialog.Conversation entréeMaison;
    [SerializeField] public Dialog.Conversation arrivéeMaman;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController")
        {

            StartCoroutine("CutScene");
            

        }   
    }

    IEnumerator CutScene()
    {
        GameCanvasManager.Instance.dialog.isCutScene = true;
        yield return new WaitForSeconds(0.1f);
        GameCanvasManager.Instance.dialog.StartDialog = entréeMaison;
        yield return new WaitForSeconds(3.2f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3.2f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3.2f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;

        //timeline1
        //waitforseconds (temps imparti)
        //forceUpdatedialog
        //waitforseconde (temps imparti avant timeline 2)
        //timeline2




        GameManager.Instance.GetComponent<GameState>().versatileGet = true;
    }
}
