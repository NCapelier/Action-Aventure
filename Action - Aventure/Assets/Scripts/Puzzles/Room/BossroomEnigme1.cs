using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossroomEnigme1 : MonoBehaviour
{
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
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
        if (switch1.GetComponent<Illuminator>().isLit == true && switch2.GetComponent<Illuminator>().isLit == true && switch3.GetComponent<Illuminator>().isLit == true)
        {
            roomCleaned = true;
        }
        if (roomCleaned == true)
        {
            exitDoor.SetActive(true);
        }

    }
}
