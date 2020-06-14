using System.Collections;
using UnityEngine;
using Player;
using GameSound;
using Lantern;

public class FallingScript : MonoBehaviour
{

    /// <summary>
    /// Xp - Make the player falling
    /// </summary>

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
            
            StartCoroutine("Falling");
            
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
        PlayerManager.Instance.controller.isDialoging = true;

        startFadingIN();

        yield return new WaitForSeconds(0.5f);
        PlayerManager.Instance.TakeDamages = 1;

        //Jouer le son de la chute
        AudioManager.Instance.Play("Player_fall");
        
        PlayerManager.Instance.gameObject.transform.position = respawnPoint.transform.position;
        LanternManager.Instance.boomerang.currentBoomerangState = boomerangState.FallBack;
        LanternManager.Instance.gameObject.transform.position = PlayerManager.Instance.gameObject.transform.position;

        //Tp le feu follet et mettre dans le bon état.

        yield return new WaitForSeconds(1f);
        
        

        startFadingOUT();
        PlayerManager.Instance.controller.isDialoging = false;
    }
}
