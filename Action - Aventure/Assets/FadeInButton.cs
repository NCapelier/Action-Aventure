﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInButton : MonoBehaviour
{
    //Button reference
    public GameObject AButton;
    private SpriteRenderer boutonRenderer;

    public bool playerHe = false;

    void Start()
    {
        playerHe = false;

        boutonRenderer = AButton.GetComponent<SpriteRenderer>();

        Color c = boutonRenderer.material.color;
        c.a = 0f;
        boutonRenderer.material.color = c;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            startFadingIN();
            playerHe = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            startFadingOUT();
            playerHe = false;
        }
    }


   

    public void startFadingIN()
    {
        StartCoroutine("FadeIn");
    }

    public void startFadingOUT()
    {
        StartCoroutine("FadeOut");
    }
}
