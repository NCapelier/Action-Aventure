using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Lantern;

public class FallingScript : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject blackScreen;
    private SpriteRenderer screenRenderer;

    private void Start()
    {
        screenRenderer = blackScreen.GetComponent<SpriteRenderer>();
     
        Color c = screenRenderer.material.color;
        c.a = 0f;
        screenRenderer.material.color = c;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerController")
        {
            PlayerManager.Instance.controller.isFalling = true;
            StartCoroutine("Falling");
            PlayerManager.Instance.controller.isFalling = false;
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

    IEnumerator FadeIn()
    {
        for(float f = 0.1f; f <= 1.1; f += 0.1f)
        {
            Color c = screenRenderer.material.color;
            c.a = f;
            screenRenderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
                

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

    IEnumerator Falling()
    {
        
        startFadingIN();

        yield return new WaitForSeconds(0.5f);
        PlayerManager.Instance.TakeDamages = 4;
        PlayerManager.Instance.gameObject.transform.position = respawnPoint.transform.position;
        
        //Tp le feu follet et mettre dans le bon état.

        yield return new WaitForSeconds(1f);
        
        

        startFadingOUT();
       
    }
}
