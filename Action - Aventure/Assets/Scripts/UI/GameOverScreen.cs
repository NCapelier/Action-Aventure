﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
   [SerializeField] private GameObject canvasJeu;

    [SerializeField] private GameObject Canvas;

    [SerializeField] private GameObject bouton;

    //FadeBlackScreen
    public GameObject blackScreen;
    private SpriteRenderer screenRenderer;

    private bool notTrigger = true;

    private void Start()
    {
        Canvas.SetActive(false);
        bouton.SetActive(false);

        screenRenderer = blackScreen.GetComponent<SpriteRenderer>();

        StartCoroutine("FadeOut");
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState.playerDead == true && notTrigger == true)
        {
            notTrigger = false;
            canvasJeu.SetActive(false);

            StartCoroutine("FadeIn");

            Canvas.SetActive(true);
            bouton.SetActive(true);
        }
    }

    public void startFadingIN()
    {
        StartCoroutine("FadeIn");
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
        blackScreen.SetActive(false);
    }

    public void Quitter()
    {
        Debug.Log("Quitter");
        AppHelper.Quit();
    }

    public void startFadingOUT()
    {
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = screenRenderer.material.color;
            c.a = f;
            screenRenderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }


    }

    IEnumerator FadeIn()
    {
        for (float f = 0.1f; f <= 1.1; f += 0.1f)
        {
            Color c = screenRenderer.material.color;
            c.a = f;
            screenRenderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

        Canvas.SetActive(true);

    }

    
}
