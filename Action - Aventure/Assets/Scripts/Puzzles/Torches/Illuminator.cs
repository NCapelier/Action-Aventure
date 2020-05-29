using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lantern;
using GameSound;

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

    //Sound
    Sound igniteClip;
    Sound burnClip;
    Sound extingClip;
    AudioSource igniteSound;
    AudioSource burnSound;
    AudioSource extingSound;
    AudioSource[] sounds;

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

        //Sound
        igniteClip = AudioManager.Instance.sounds_notUniqueObject["Fire_ignite"];
        burnClip = AudioManager.Instance.sounds_notUniqueObject["Fire_burn"];
        extingClip = AudioManager.Instance.sounds_notUniqueObject["Will_o_exting"];
        AudioManager.Instance.MakeAudioSource(igniteClip, gameObject);
        AudioManager.Instance.MakeAudioSource(burnClip, gameObject);
        AudioManager.Instance.MakeAudioSource(extingClip, gameObject);
        sounds = gameObject.GetComponents<AudioSource>();
        igniteSound = sounds[0];
        burnSound = sounds[1];
        extingSound = sounds[2];
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

                //Sound
                burnSound.Stop();
                extingSound.Play();
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

            //Sound
            igniteSound.Play();
            burnSound.Play();
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
