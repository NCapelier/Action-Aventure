﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [HideInInspector]
    public bool isLit;
    private SpriteRenderer flame;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        flame = GetComponent<SpriteRenderer>();
        flame.enabled = false;
        isLit = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hinky")
        {
            Light();
        }
    }
    /// <summary>
    /// Lights flame. To be called when the right object collides.
    /// </summary>
    protected virtual void Light()
    {
        if (!isLit)
        {
            flame.enabled = true;
            isLit = true;
        }
    }

    public void PutOut()
    {
        if (isLit)
        {
            flame.enabled = false;
            isLit = false;
        }
    }   
}