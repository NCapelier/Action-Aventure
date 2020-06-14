using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lantern;
using GameSound;
using GameManagement;

public class TorchTTK : MonoBehaviour
{
    public bool isLit;
    private GameObject flameObject;
    private ParticleSystem flame;
    public float Duration;
    private bool playerHere;

    public float StartDuration;

    public bool isCutScene;

    bool isRoutine = false;



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
        isCutScene = false;
        flameObject = gameObject.GetChildNamed("Flame");
        flame = flameObject.GetComponent<ParticleSystem>();
        flame.gameObject.SetActive(false);
        isLit = false;
        playerHere = false;

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

        Duration = StartDuration;

        StartCoroutine(PauseLoops());
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("PlayerController") && LanternManager.Instance.boomerang.currentBoomerangState == boomerangState.Static && LanternManager.Instance.hideLight.currentLightState == lightState.Displayed) || other.gameObject.CompareTag("Hinky"))
            Debug.Log("This is called");
        playerHere = true;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hinky" && LanternManager.Instance.hideLight.currentLightState == lightState.Displayed)
        {
           
            playerHere = true;
            
        }
 
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hinky")
        {
            playerHere = false;
            //StartCoroutine("TTK");

        }
    }

   

    private void Update()
    {
        if(playerHere == true)
        {
           Duration = StartDuration;
            Light();
        }
        
        if(playerHere == false && isLit == true && !isRoutine)
        {
            isRoutine = true;
            StartCoroutine(TTK());

            
        }
        if (Duration <= 0)
        {
            isLit = false;
            Duration = StartDuration;
            burnSound.Stop();
            extingSound.Play();
        }


        if (!isLit)
        {
             flame.gameObject.SetActive(false);
        }else if (isLit)
        {

            flame.gameObject.SetActive(true);
        }

    }

    private void Light()
    {
        if (!isLit)
        {
            //Sound
            igniteSound.Play();
            burnSound.Play();
        }

        isLit = true;
    }

    IEnumerator TTK()
    {
        if(playerHere == false && isLit == true)
        {
            Duration--;
            yield return new WaitForSeconds(1f);
            StartCoroutine("TTK");

        }
        else
        {
            isRoutine = false;
        }
       
    }

    IEnumerator PauseLoops()
    {
        if (GameManager.Instance.gameState.inPause)
        {
            if (burnSound.isPlaying)
            {
                burnSound.Pause();

                yield return new WaitUntil(() => !GameManager.Instance.gameState.inPause);
                burnSound.UnPause();
            }
        }
        else
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(PauseLoops());

        }
    }
}
