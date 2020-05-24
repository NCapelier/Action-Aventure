using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameManagement;

public class TriggerDialogFrere : MonoBehaviour
{
 
    //bouton reference
    public GameObject AButton;
    private SpriteRenderer boutonRenderer;

    //player here = true when the player enter the dialog'trigger box (Use full to don't use a trigger stay).
    public bool playerH;

    //dialog Lines
    [SerializeField] private Dialog.Conversation dial1;
    [SerializeField] private Dialog.Conversation dial2;


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

    // Update is called once per frame
    void Update()
    {
      
       if (Input.GetButtonDown("A_Button") && playerH == true)
       {

            if (PlayerManager.Instance.controller.isDialoging == false && GameManager.Instance.GetComponent<GameState>().firstDialogFC == true )
            {//Switch de dialog pour le "...".
                dial1 = dial2;
            }

            GameCanvasManager.Instance.dialog.StartDialog = dial1;

            GameManager.Instance.GetComponent<GameState>().firstDialogFC = true;

            playerH = false; 

           
        }

        

    }

    //Quand le player sort de la zone pouvant déclencher le dialogue, le bouton fadeOut.
    private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "PlayerController")
            {
            startFadingOUT();
            playerH = false;
            }
        }

    //Fade in bouton A
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

    //Fade out bouton A
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
