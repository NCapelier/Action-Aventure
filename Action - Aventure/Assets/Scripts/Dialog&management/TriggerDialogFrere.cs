using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameManagement;

public class TriggerDialogFrere : MonoBehaviour
{
    public bool playerH;

    private TriggerDialogFrere script;

    public GameObject AButton;
    private SpriteRenderer boutonRenderer;


    [SerializeField] private Dialog.Conversation dial1;
    [SerializeField] private Dialog.Conversation dial2;


    // Start is called before the first frame update
    void Start()
    {
        script = GetComponent<TriggerDialogFrere>();

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
            {
                dial1 = dial2;
            }

            GameCanvasManager.Instance.dialog.StartDialog = dial1;

            GameManager.Instance.GetComponent<GameState>().firstDialogFC = true;

           
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
