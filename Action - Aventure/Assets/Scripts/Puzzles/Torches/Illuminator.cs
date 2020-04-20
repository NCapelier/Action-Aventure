using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lantern;

public class Illuminator : MonoBehaviour
{
    /// <summary>
    /// This script makes the behaviour of illuminator (la machine a incandescence)
    /// </summary>
    public bool isLit;
   

    // Start is called before the first frame update
    void Start()
    {
        isLit = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (!isLit)
            {
                //Jouer animation déclenchement
                //activation light
            }
            else if (isLit)
            {

                //jouer animation en sens inverse
            }


        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hinky" && LanternManager.Instance.flashLight.currentFlashState == flashState.FlashingUp)
        {
            isLit = true;
            Debug.Log("called");

        }
        


    }
}
