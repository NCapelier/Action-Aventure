using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lantern;
using GameSound;

public class TorchTTK : MonoBehaviour
{
    public bool isLit;
    private GameObject flameObject;
    private ParticleSystem flame;
    public float Duration;
    private bool playerHere;

    public bool isCutScene;

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
    }

    private void Start()
    {
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
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hinky" || (col.gameObject.CompareTag("Player") && LanternManager.Instance.hideLight.currentLightState == lightState.Displayed))
        {
            Light();
            playerHere = true;
            StartCoroutine("TTK");
        }
 
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hinky")
        {
            playerHere = false;
            StartCoroutine("TTK");

        }
    }

    private void Update()
    {
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
        
        isLit = true;

        //Sound
        igniteSound.Play();
        burnSound.Play();

    }

    IEnumerator TTK()
    {
        if (playerHere == false && isLit == true)
        {
            yield return new WaitForSeconds(Duration);
            isLit = false;

            //Sound
            burnSound.Stop();
            extingSound.Play();
        }
    }
}
