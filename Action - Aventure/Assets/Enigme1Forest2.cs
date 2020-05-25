using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enigme1Forest2 : MonoBehaviour
{
    [SerializeField] private GameObject flambeau;

    

    // Update is called once per frame
    void Update()
    {
        if (flambeau.GetComponent<TorchTTK>().isLit == true)
        {
            gameObject.SetActive(false);
        }
    }
}
