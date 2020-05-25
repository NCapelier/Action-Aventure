using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class ZoneScripter : MonoBehaviour
{

    /// <summary>
    /// This script makes the Ui_Zone_text apprering and vanishing;
    /// </summary>

    public GameObject ApperingText;
    public static bool isTrigger;

    public int timeBeforeVanishing;

    public GameObject monstreUi;
    public GameObject BuissonUi;

    private GameObject GOToRender;

    // Start is called before the first frame update

    private void Start()
    {
        GOToRender = null;
        monstreUi.SetActive(false);
        BuissonUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState.isDungeon == true)
        {
            GOToRender = monstreUi;
        }else 
        {
            GOToRender = BuissonUi;
        }

     
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
        GOToRender.SetActive(true);
        yield return new WaitForSeconds(timeBeforeVanishing);
        ApperingText.GetComponent<ZoneIntroduction>().textComponent.enabled = false;
        GOToRender.SetActive(false);

    }
}
