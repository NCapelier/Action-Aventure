using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removingGrid : MonoBehaviour
{
    [SerializeField] private GameObject grid;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if(gameObject.GetComponent<Illuminator>().isLit == true)
        {
            grid.SetActive(false);
        }
        else
        {
            grid.SetActive(true);
        }
        
    }
}
