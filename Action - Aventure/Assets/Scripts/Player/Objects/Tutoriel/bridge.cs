using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class bridge : MonoBehaviour
{
    private CircleCollider2D CC;
    private BoxCollider2D bxC;
    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        CC = gameObject.GetComponent<CircleCollider2D>();
        bxC = gameObject.GetComponent<BoxCollider2D>();
        Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController")
        {
            Animator.enabled = true;
            CC.enabled = false;

            
            
            bxC.enabled = true;

        }
    }
}
