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

    //Sound
    Sound pressureClip;
    AudioSource pressureSound;

    // Start is called before the first frame update
    private void Start()
    {
        tileB = apperingFloor.GetComponent<BoxCollider2D>();
        tileR = apperingFloor.GetComponent<TilemapRenderer>();
        tileR.enabled = false;

        //Sound
        pressureClip = AudioManager.Instance.sounds_notUniqueObject["Activate_deactivate"];
        AudioManager.Instance.MakeAudioSource(pressureClip, gameObject);
        pressureSound = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            tileB.enabled = false;
            tileR.enabled = true;

            pressureSound.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            tileB.enabled = true;
            tileR.enabled = false;

            pressureSound.Play();
        }
    }


}
