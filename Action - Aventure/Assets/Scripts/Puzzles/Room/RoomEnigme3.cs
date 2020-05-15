using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnigme3 : MonoBehaviour
{
    
    public GameObject illuminator1;
    public GameObject illuminator2;

    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if( illuminator1.GetComponent<Illuminator>().isLit == true && illuminator1.GetComponent<Illuminator>().isLit == true)
        {
            door.SetActive(true);
        }
    }
}
