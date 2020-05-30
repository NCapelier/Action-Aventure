using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackFadeOUT : MonoBehaviour
{
    public GameObject logo;
    public SpriteRenderer logoRenderer;

    public GameObject allBoutons;

    public GameObject blackScreen;
    private SpriteRenderer screenRenderer;
    // Start is called before the first frame update
    void Start()
    {
        allBoutons.SetActive(false);
        screenRenderer = blackScreen.GetComponent<SpriteRenderer>();
        logoRenderer = logo.GetComponent<SpriteRenderer>();

        StartCoroutine("FadeInlogo");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startFadingOUT()
    {
        StartCoroutine("FadeOutBlackScreen");
    }
    public void startFadingIN()
    {
        StartCoroutine("FadeInBlackScreen");
    }

    IEnumerator FadeOutBlackScreen()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = screenRenderer.material.color;
            c.a = f;
            screenRenderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

        
    }

    IEnumerator FadeOUTBlackScreen()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color d = logoRenderer.material.color;
            d.a = f;
            logoRenderer.material.color = d;
            yield return new WaitForSeconds(0.05f);
        }

    }

    IEnumerator FadeInlogo()
    {
        for (float f = 0.1f; f <= 1.1; f += 0.1f)
        {
            Color d = logoRenderer.material.color;
            d.a = f;
            logoRenderer.material.color = d;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine("FadeOUTBlackScreen");

        StartCoroutine("FadeOutBlackScreen");
        yield return new WaitForSeconds(0.3f);
        allBoutons.SetActive(true);
    }
}