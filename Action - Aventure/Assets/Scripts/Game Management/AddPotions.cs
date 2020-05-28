using System.Collections;
using UnityEngine;
using GameManagement;
using Player;

public class AddPotions : MonoBehaviour
{

    //Button reference
    public GameObject AButton;
    private SpriteRenderer boutonRenderer;

    public Dialog.Conversation Potion;

    public bool playerHe;
    private bool Finish;


    // Start is called before the first frame update
    void Start()
    {
        playerHe = false;

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
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            startFadingIN();
            playerHe = true;
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if(GameManager.Instance.GetComponent<GameState>().potionGet == true){

            GetComponent<SpriteRenderer>().enabled = false;
        }

        if (playerHe == true && Input.GetButtonDown("A_Button") && GameManager.Instance.GetComponent<GameState>().potionGet == false)
        {
            
            
            PotionsTextScript.potionAmount = 1;
            PotionsTextScript.maxPotionAmount = 1;

            Finish = true;

            


        }

      if (Finish == true)
        {
            StartCoroutine("Dialog");

            
        }

    }

   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController")){
            startFadingOUT();
            playerHe = false;
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

    IEnumerator Dialog()
    {
        PlayerManager.Instance.controller.isDialoging = true;
        GameCanvasManager.Instance.dialog.StartDialog = Potion;

        yield return new WaitForSeconds(0.1f);

        GameManager.Instance.GetComponent<GameState>().potionGet = true;
        Finish = false;
        Destroy(gameObject);
    }
}
