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

   //Light
    private GameObject pointLight;

    //animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
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
            

           
        
    }
        public void GetAnimationEvent(string EventMessage)
        {
             if (EventMessage.Equals("isLit"))
             {
            pointLight.SetActive(true);
             }

        }
            private void OnTriggerStay2D(Collider2D col)
            {
        
                if (col.gameObject.tag == "Hinky" && LanternManager.Instance.flashLight.currentFlashState == flashState.FlashingUp)
                {

                Debug.Log("called");
                isLit = true;
                StartCoroutine("Restart");
            
            

                }
        
            }

    IEnumerator Restart()
    {
        restart = true;
        yield return new WaitForSeconds(0.1f);
        restart = false;
    }
    
}
