using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnigme2 : MonoBehaviour
{
    
    public GameObject torch1;
    public GameObject torch2;
    public GameObject illuminator1;
    public GameObject illuminator2;

    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(torch1.GetComponent<TorchTTK>().isLit == true && torch2.GetComponent<TorchTTK>().isLit == true && illuminator1.GetComponent<Illuminator>().isLit == true && illuminator1.GetComponent<Illuminator>().isLit == true)
        {
            door.SetActive(false);
        }
    }
}
