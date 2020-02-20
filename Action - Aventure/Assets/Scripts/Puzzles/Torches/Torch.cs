using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private bool isLit;
    private SpriteRenderer flame;
    // Start is called before the first frame update
    void Start()
    {
        flame = gameObject.GetComponent<SpriteRenderer>();
        flame.enabled = false;
        isLit = false;
    }

    protected virtual void Light()
    {
        if (!isLit)
        {
            flame.enabled = true;
            isLit = true;
        }
    }

    public void PutOut()
    {
        if (isLit)
        {
            flame.enabled = false;
            isLit = false;
        }
    }   
}
