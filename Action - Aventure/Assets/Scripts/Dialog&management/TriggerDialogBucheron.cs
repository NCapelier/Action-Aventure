using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameManagement;
using UnityEngine.Playables;



public class TriggerDialogBucheron : MonoBehaviour
{
    public GameObject enemy;

    public GameObject waypoints;


    private BoxCollider2D bxCollider;

    public Dialog.Conversation dialHelp1;
    public Dialog.Conversation dialHelp2;
    public Dialog.Conversation dialHelp3;
    private bool dialog1Finished;

    public GameObject flambeau;

    private bool playerHere;

    private PlayableDirector timeline;

    public float timerClip = 0f;

    private bool starTimer = false;

    private bool dialog2fin = false;


    // Start is called before the first frame update
    void Start()
    {


        bxCollider = GetComponent<BoxCollider2D>();
        flambeau.GetComponent<TorchTTK>().isLit = true;

        timeline = GetComponent<PlayableDirector>();

        timeline.Stop();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController")
        {
            playerHere = true;

            bxCollider.enabled = false;

            PlayerManager.Instance.controller.isDialoging = true;

            GameCanvasManager.Instance.dialog.StartDialog = dialHelp1;


        }



    }

    private void Update()
    {
        if (GameCanvasManager.Instance.dialog.runningConversation == false && playerHere == true)
        {
            PlayerManager.Instance.controller.isDialoging = true;

            timeline.Play();

            starTimer = true;
            

            
        }


        if (timerClip >= 1150 && starTimer == true)
        {
            starTimer = false;

            GameCanvasManager.Instance.dialog.StartDialog = dialHelp2;

            //jouer coup de feu;

            timeline.Stop();

            flambeau.GetComponent<TorchTTK>().isLit = false;

            dialog2fin = true;

            if (GameCanvasManager.Instance.dialog.runningConversation == false && dialog2fin == true)
            {
                Debug.Log("called");
                PlayerManager.Instance.controller.isDialoging = true;


                GameCanvasManager.Instance.dialog.StartDialog = dialHelp3;
            }
        }

        

       



        if (starTimer == true)
        {
            timerClip += 1;
        }
    }

}
