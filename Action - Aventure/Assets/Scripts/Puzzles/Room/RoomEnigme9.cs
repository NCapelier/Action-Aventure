using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnigme9 : MonoBehaviour
{
    public GameObject illuminator0;
    public GameObject illuminator1;
    public GameObject illuminator2;
    public GameObject flambeau;
    private GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        door = gameObject.GetChildNamed("Exit");
    }

    // Update is called once per frame
    void Update()
    {
        if(illuminator0.GetComponent<Illuminator>().isLit == true && illuminator1.GetComponent<Illuminator>().isLit == true && illuminator2.GetComponent<Illuminator>().isLit == true && flambeau.GetComponent<TorchTTK>().isLit == true){
            door.SetActive(true);
        }
    }
}
