using UnityEngine;

public class Fence : MonoBehaviour
{
    //object component
    private BoxCollider2D bxC;
    private Animator Animator;

    //Button reference
    private Animator buttonAnimator;
    private GameObject pressBouton;
    private BoxCollider2D buttonCollider;
    private SpriteRenderer buttonRenderer;
    public bool open;

    // Start is called before the first frame update
    void Start()
    {
        bxC = gameObject.GetComponent<BoxCollider2D>();
        Animator = gameObject.GetComponent<Animator>();
        

        pressBouton = gameObject.GetChildNamed("360_A");

        pressBouton.SetActive(false);
        buttonAnimator = pressBouton.GetComponent<Animator>();
        buttonCollider = pressBouton.GetComponent <BoxCollider2D>();
        buttonRenderer = pressBouton.GetComponent<SpriteRenderer>();
        open = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerController" && open == false)
        {
            pressBouton.SetActive(true);
            buttonAnimator.enabled = true;
            buttonRenderer.enabled = true;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController" && Input.GetButtonDown("A_Button"))
        {

                Animator.enabled = true;
                bxC.enabled = false;

            open = true;
            buttonAnimator.enabled = false;
            buttonCollider.enabled = true;
            buttonRenderer.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController" )
        {
            buttonAnimator.enabled = false;
            buttonRenderer.enabled = false;
        }
    }

   
}
