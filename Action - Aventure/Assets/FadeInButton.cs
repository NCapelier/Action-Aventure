using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInButton : MonoBehaviour
{
    //Button reference
    public GameObject AButton;
    private SpriteRenderer boutonRenderer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFadingIN()
    {
        StartCoroutine("FadeIn");
    }

    public void startFadingOUT()
    {
        StartCoroutine("FadeOut");
    }
}
