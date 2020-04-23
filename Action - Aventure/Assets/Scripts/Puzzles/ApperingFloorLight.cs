using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ApperingFloorLight : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (gameObject.GetComponent<Illuminator>().isLit == true)
        {
            tileB.enabled = false;
            tileR.enabled = true;
        }
        else if (gameObject.GetComponent<Illuminator>().isLit == false)
        {
            tileB.enabled = true;
            tileR.enabled = false;
        }
    }
}
