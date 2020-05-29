using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressX : MonoBehaviour
{

    //Button reference
    private Animator buttonAnimator;
    private GameObject pressBouton;
    private SpriteRenderer buttonRenderer;

    // Start is called before the first frame update
    void Start()
    {
        pressBouton = gameObject.GetChildNamed("360_X");
        buttonAnimator = pressBouton.GetComponent<Animator>();
        buttonRenderer = pressBouton.GetComponent<SpriteRenderer>();

        pressBouton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            pressBouton.SetActive(true);
            if (Input.GetButton("X_Button"))
            {
                pressBouton.SetActive(false);
            }
            if (Input.GetButtonUp("X_Button"))
            {
                pressBouton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            pressBouton.SetActive(false);
        }
    }

}
