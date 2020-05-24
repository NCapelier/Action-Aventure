using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lantern;

public class Illuminator : MonoBehaviour
{
    /// <summary>
    ///  XP - This script makes the behaviour of illuminator (la machine a incandescence)
    /// </summary>
    public bool isLit;
    private float duration;
    public float StartDuration;
    private bool restart;

    public bool playerHere;
   //Light
    private GameObject pointLight;

    //animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerHere = false;
        isLit = false;
        duration = StartDuration;
        restart = false;

        

        pointLight = gameObject.GetChildWithTag("Light");

        //animator stuff
        anim = GetComponent<Animator>();
        pointLight.SetActive(false);


    }
    // Update is called once per frame
    void Update()
    {
        if (restart == true)
        {
            duration = StartDuration;
        }

        if (isLit){

            anim.SetBool("isLit", true);

                if (duration <= 0)
                {
                isLit = false;
                duration = StartDuration;
                anim.SetBool("isLit", false);
                pointLight.SetActive(false);
            }
                else {
                isLit = true;
                duration -= Time.deltaTime;
                }
        }
            
        if(playerHere == true && LanternManager.Instance.flashLight.currentFlashState == flashState.FlashingUp)
        {
            isLit = true;
            StartCoroutine("Restart");
        }
           
        
    }
        public void GetAnimationEvent(string EventMessage)
        {
             if (EventMessage.Equals("isLit"))
             {
            pointLight.SetActive(true);
             }

        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerController" || collision.gameObject.tag == "Hinky")
        {
            playerHere = true;
            
        }
    }
   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController" || collision.gameObject.tag == "Hinky")
        {
            playerHere = false;
        }
    }

    IEnumerator Restart()
    {
        restart = true;
        yield return new WaitForSeconds(0.1f);
        restart = false;
    }
    
}
