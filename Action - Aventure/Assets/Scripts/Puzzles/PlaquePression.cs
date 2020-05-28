﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaquePression : MonoBehaviour
{
    public GameObject apperingFloor;
    private TilemapRenderer tileR;
    private BoxCollider2D tileB;
    private bool isActivated;


    // Start is called before the first frame update
    private void Start()
    {
        tileB = apperingFloor.GetComponent<BoxCollider2D>();
        tileR = apperingFloor.GetComponent<TilemapRenderer>();
        tileR.enabled = false;
       
    }

    private void Update()
    {
        if(isActivated == true)
        {
            tileB.enabled = false;
            tileR.enabled = true;
        }
        else {
            tileB.enabled = true;
            tileR.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            isActivated = true;
            
            //jouer Animation appuyé
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            isActivated = false;
           
            //jouer Animation resort
        }
    }


}
