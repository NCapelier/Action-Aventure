using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameManagement;
public class TriggerDialogPNJCroque : MonoBehaviour
{

    /// <summary>
    /// XP -  Dialogue Manager du Croque mort.
    /// </summary>
     private bool playerH;

    //Button reference
    public GameObject AButton;
    private SpriteRenderer boutonRenderer;

    

    public Dialog.Conversation dial1;
    public Dialog.Conversation dial2;
    public Dialog.Conversation dial3;

    //Dialog Reference

    // Start is called before the first frame update
    void Start()
    {
        playerH = false;
        boutonRenderer = AButton.GetComponent<SpriteRenderer>();

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
            playerH = true;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("A_Button") && playerH == true && GameManager.Instance.GetComponent<GameState>().firstDialogCM == false)
        {
       
                GameCanvasManager.Instance.dialog.StartDialog = dial1;

                GameManager.Instance.GetComponent<GameState>().firstDialogCM = true;
                
           
        }

        if (Input.GetButtonDown("A_Button") && playerH == true && GameManager.Instance.GetComponent<GameState>().versatileGet == true)
        {

            GameCanvasManager.Instance.dialog.StartDialog = dial3;

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
