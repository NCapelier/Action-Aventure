﻿using System.Collections;
using UnityEngine;
using GameManagement;
using Lantern;

public class Book : MonoBehaviour
{
    [SerializeField] Dialog.Conversation bookText;

    [SerializeField] private GameObject aButton;
    [SerializeField] private GameObject crux;
    [SerializeField] private GameObject trappe;
    [SerializeField] private GameObject maxDistance;

    public bool trigger;

    [SerializeField] private SpriteRenderer buttonRenderer;
    [SerializeField] private bool playerH;


    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
        playerH = false;
        buttonRenderer = aButton.GetComponent<SpriteRenderer>();

        Color c = buttonRenderer.material.color;
        c.a = 0f;
        buttonRenderer.material.color = c;

        trappe.GetComponent<Animator>().enabled = false;
        trappe.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void startFadingIN()
    {
        StartCoroutine("FadeIn");
    }

    public void startFadingOUT()
    {
        StartCoroutine("FadeOut");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController")
        {
            startFadingIN();
            playerH = true;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        if(playerH == true && Input.GetButtonDown("A_Button"))
        {
            GameCanvasManager.Instance.dialog.StartDialog = bookText; 
        }

        if (playerH = true && LanternManager.Instance.flashLight.currentFlashState == flashState.FlashingUp)
        {
            trigger = true;
        }

        if (trigger == true)
        {
            
            crux.transform.position = maxDistance.transform.position;
          
            trappe.GetComponent<Animator>().enabled = true;
            trappe.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController")
        {
            startFadingOUT();
            playerH = false;
        }

      
    }


    IEnumerator FadeIn()
    {
        for (float f = 0.25f; f <= 1.1; f += 0.25f)
        {
            Color c = buttonRenderer.material.color;
            c.a = f;
            buttonRenderer.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }


    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.1f)
        {
            Color c = buttonRenderer.material.color;
            c.a = f;
            buttonRenderer.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }


    }
}
