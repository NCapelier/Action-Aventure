using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apperingEnnemy : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D bxC;
    public GameObject ennemy1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bxC = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController")
        {
            StartCoroutine("Animation");
           
        }
    }

    IEnumerator Animation()
    {
        bxC.enabled = false;
        animator.enabled = true;
        yield return new WaitForSeconds(2f);
        Instantiate(ennemy1, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
