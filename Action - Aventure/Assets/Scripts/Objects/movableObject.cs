using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movableObject : MonoBehaviour
{

    //If false = MoveHorizontale able
    public bool moveVertical;
    public bool moveHorizontal;
    public GameObject pointMin;
    public GameObject pointMax;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()
    {
        if (moveVertical == true)
        {
            if(transform.position.y > pointMax.transform.position.y)
            {
                transform.position = pointMax.transform.position;
            }
            if(transform.position.y < pointMin.transform.position.y)
            {
                transform.position = pointMin.transform.position;
            }

        }
        if (moveHorizontal == true)
        {
            if (transform.position.x > pointMax.transform.position.x)
            {
                transform.position = pointMax.transform.position;
            }
            if (transform.position.x < pointMin.transform.position.x)
            {
                transform.position = pointMin.transform.position;
            }

        }
    }


}
