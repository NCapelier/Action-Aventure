using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApperingUI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer selfItem;
    [SerializeField] private float delais;

    [SerializeField] private bool triggerOnce;

    // Start is called before the first frame update
    void Awake()
    {
        

        Color c = selfItem.material.color;
        c.a = 0f;
        selfItem.material.color = c;
    }

    private void OnEnable()
    {
        if (triggerOnce == false)
        {
            StartCoroutine("FadeIn");
        }
       
    }

    IEnumerator FadeIn()
    {
        Debug.Log("FadeIn");
            triggerOnce = true;
            yield return new WaitForSeconds(delais);

            for (float f = 0.1f; f <= 1.1; f += 0.1f)
            {
                Color c = selfItem.material.color;
                c.a = f;
                selfItem.material.color = c;
                yield return new WaitForSeconds(0.04f);
            }
    }
        

}


