using System.Collections;
using UnityEngine;
using GameManagement;

public class GetLantern : MonoBehaviour
{
    /// <summary>
    /// XP -  This script makes the player capable to get the lantern
    /// </summary>

    //Button Reference
    public GameObject Button;
    private SpriteRenderer boutonRenderer;

    private bool playerHere;

    //dialog Lines
    public Dialog.Conversation lantern;

    private void Start()
    {
        boutonRenderer = Button.GetComponent<SpriteRenderer>();
        playerHere = false;


       //Set opacity to 0 of the A Button
        Color c = boutonRenderer.material.color;
        c.a = 0f;
        boutonRenderer.material.color = c;
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
            playerHere = true;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("A_Button") && playerHere == true)
        {
  
            GameCanvasManager.Instance.dialog.StartDialog = lantern;

            GameManager.Instance.GetComponent<GameState>().lanternGet = true;

            gameObject.SetActive(false);
            
        }
    }
  

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController")
        {
            startFadingOUT();
            playerHere = false;
        }
    }


    IEnumerator FadeIn()
    {
        for (float f = 0.25f; f <= 1.1; f += 0.25f)
        {
            Color c = boutonRenderer.material.color;
            c.a = f;
            boutonRenderer.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }


    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.1f)
        {
            Color c = boutonRenderer.material.color;
            c.a = f;
            boutonRenderer.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }


    }
}
