using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oppeningDoorF2 : MonoBehaviour
{
    private BoxCollider2D boxCol;
    private CapsuleCollider2D capsCol;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        capsCol = gameObject.GetComponent<CapsuleCollider2D>();
        boxCol = gameObject.GetComponent<BoxCollider2D>();

        animator.enabled = false;
        boxCol.enabled = true;
        capsCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnigmeDoorForest2.isFinish == true)
        {
            animator.enabled = true;
            boxCol.enabled = false;
            capsCol.enabled = true;
        }
       
    }
}
