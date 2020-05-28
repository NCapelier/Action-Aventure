using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class TreasureBehaviour : MonoBehaviour
{
    [SerializeField] Dialog.Conversation rewardsText;

    [SerializeField] private GameObject aButton;
    [SerializeField] private SpriteRenderer buttonRenderer;
    private bool playerH;


    // Start is called before the first frame update
    void Start()
    {
        playerH = false;
        buttonRenderer = aButton.GetComponent<SpriteRenderer>();

        Color c = buttonRenderer.material.color;
        c.a = 0f;
        buttonRenderer.material.color = c;
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
            GameCanvasManager.Instance.dialog.StartDialog = rewardsText;
            GoldTextScript.coinAmount += 10;
            gameObject.SetActive(false);
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
            Color c = buttonRenderer.material.color;
            c.a = f;
            buttonRenderer.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }


    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.1f)
        {
            Color c = buttonRenderer.material.color;
            c.a = f;
            buttonRenderer.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }


    }
}
