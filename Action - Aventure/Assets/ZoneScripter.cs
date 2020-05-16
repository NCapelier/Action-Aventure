using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneScripter : MonoBehaviour
{

    /// <summary>
    /// This script makes the Ui_Zone_text apprering and vanishing;
    /// </summary>

    public GameObject ApperingText;
    public static bool isTrigger;

    public int timebeforVanishing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if(isTrigger == true)
        {
            StartCoroutine("TextVanishing");
        }
    }

    IEnumerator TextVanishing()
    {
        isTrigger = false;
        yield return new WaitForSeconds(0.2f);
        ApperingText.GetComponent<ZoneIntroduction>().textComponent.enabled = true;
        yield return new WaitForSeconds(timebeforVanishing);
        ApperingText.GetComponent<ZoneIntroduction>().textComponent.enabled = false;
        
    }
}
