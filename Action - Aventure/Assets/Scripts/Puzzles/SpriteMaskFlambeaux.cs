using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class SpriteMaskFlambeaux : MonoBehaviour
{
    Light2D mainLight = null;

    SpriteMask sm = null;

    // Start is called before the first frame update
    void Start()
    {
        sm = GetComponent<SpriteMask>();
        mainLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        sm.gameObject.transform.localScale = new Vector3(mainLight.pointLightOuterRadius * 0.05f, mainLight.pointLightOuterRadius * 0.05f, sm.gameObject.transform.localScale.z);
    }
}
