using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caravaneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject AButton;

    void Start()
    {
        AButton = gameObject.GetChildNamed("A_360");
        AButton.SetActive(false);
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AButton.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("A_Button"))
        {
            //Transition vers intérieur caravane
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        AButton.SetActive(false);
    }
}
