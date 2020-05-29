using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using GameSound;

public class PlaquePression : MonoBehaviour
{
    public GameObject apperingFloor;
    private TilemapRenderer tileR;
    private BoxCollider2D tileB;
    private bool isActivated;
    private Animator anim;
    //Sound
    Sound pressureClip;
    AudioSource pressureSound;

    // Start is called before the first frame update
    private void Start()
    {
        tileB = apperingFloor.GetComponent<BoxCollider2D>();
        tileR = apperingFloor.GetComponent<TilemapRenderer>();
        tileR.enabled = false;
        anim = GetComponent<Animator>();
        anim.enabled = false;
        //Sound
        pressureClip = AudioManager.Instance.sounds_notUniqueObject["Activate_deactivate"];
        AudioManager.Instance.MakeAudioSource(pressureClip, gameObject);
        pressureSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(isActivated == true)
        {
            tileB.enabled = false;
            tileR.enabled = true;

            pressureSound.Play();
        }
        else {
            tileB.enabled = true;
            tileR.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            isActivated = true;

            //jouer Animation appuyé
            anim.enabled = true;
            anim.SetBool("Off", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            isActivated = false;
           
            //jouer Animation resort
            tileB.enabled = true;
            tileR.enabled = false;

            anim.SetBool("Off", true);
            pressureSound.Play();
        }
    }


}
