using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnigme5 : MonoBehaviour
{
    public GameObject door;

    public GameObject flambeau0;
    public GameObject flambeau1;
    public GameObject flambeau2;
    public GameObject flambeau3;
    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(flambeau0.GetComponent<TorchTTK>().isLit == true && flambeau1.GetComponent<TorchTTK>().isLit == true && flambeau2.GetComponent<TorchTTK>().isLit == true && flambeau3.GetComponent<TorchTTK>().isLit == true)
        {
            door.SetActive(true);
        }
    }
}
