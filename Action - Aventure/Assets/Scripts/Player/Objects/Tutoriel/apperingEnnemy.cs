using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apperingEnnemy : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D bxC;
    public GameObject ennemy1;
    private SpriteRenderer buttonRenderer;
    public Light pointLight;
    private SpriteRenderer humanRenderer;

    private GameObject pressButton;
   

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bxC = GetComponent<BoxCollider2D>();
        humanRenderer = GetComponent<SpriteRenderer>();

        buttonRenderer = GetComponent<SpriteRenderer>();

        pressButton = gameObject.GetChildNamed("360_RB");
        pressButton.SetActive(false);

        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController")
        {
            StartCoroutine("Animation");
            pressButton.SetActive(true);
        }
    }

    IEnumerator Animation()
    {
        bxC.enabled = false;
        animator.enabled = true;
        yield return new WaitForSeconds(2f);
        humanRenderer.enabled = false;
        Instantiate(ennemy1, transform.position, Quaternion.identity);
        //pointLight.GetComponent<Light>().enabled = false;
        animator.enabled = false;
        gameObject.SetActive(false);
        
        
    }
}
