using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnigme1 : MonoBehaviour
{
    public GameObject illuminator1;
    public GameObject illuminator2;
    public GameObject exitDoor;

    private bool roomCleaned;

    // Start is called before the first frame update
    void Start()
    {
        roomCleaned = false;
        exitDoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(illuminator1.GetComponent<Illuminator>().isLit == true && illuminator2.GetComponent<Illuminator>().isLit == true)
        {
            roomCleaned = true;
        }
        if(roomCleaned == true)
        {
            exitDoor.SetActive(true);
        }
                
    }
}
