using UnityEngine;

public class Trésor1Foret1 : MonoBehaviour
{
    [SerializeField] private GameObject flambeau1;
    [SerializeField] private GameObject flambeau2;
    [SerializeField] private GameObject flambeau3;

    private bool enigmeDone = false;
    void Update()
    {
        if(flambeau1.GetComponent<TorchTTK>().isLit == true && flambeau2.GetComponent<TorchTTK>().isLit == true && flambeau3.GetComponent<TorchTTK>().isLit == true)
        {
            enigmeDone = true;
        }

        if(enigmeDone == true)
        {
            gameObject.SetActive(false);
        }
    }
}
