using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameManagement;


public class TriggerDialogBucheron : MonoBehaviour
{

    private BoxCollider2D bxColiider;

    public Dialog.Conversation dialHelp1;
    public Dialog.Conversation dialHelp2;
    private bool dialog1Finished;

    public GameObject flambeau;

    private bool playerHere;

    // Start is called before the first frame update
    void Start()
    {
        bxColiider = GetComponent<BoxCollider2D>();
        flambeau.GetComponent<TorchTTK>().isLit = true;
        playerHere = false;
        dialog1Finished = false;
    }

    private void Update()
    {
        

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController")
        {
            playerHere = true;

        }
    }


    
}
