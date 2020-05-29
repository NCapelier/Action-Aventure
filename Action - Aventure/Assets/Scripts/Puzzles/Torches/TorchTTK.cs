using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lantern;

public class TorchTTK : MonoBehaviour
{
    public bool isLit;
    private GameObject flameObject;
    private ParticleSystem flame;
    public float Duration;
    private bool playerHere;

    public bool isCutScene;

    // Start is called before the first frame update
    void Start()
    {
        isCutScene = false;
        flameObject = gameObject.GetChildNamed("Flame");
        flame = flameObject.GetComponent<ParticleSystem>();
        flame.gameObject.SetActive(false);
        isLit = false;
        playerHere = false;
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hinky" || (col.gameObject.CompareTag("Player") && LanternManager.Instance.hideLight.currentLightState == lightState.Displayed))
        {
            Light();
            playerHere = true;
            StartCoroutine("TTK");
        }
 
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hinky")
        {
            playerHere = false;
            StartCoroutine("TTK");

        }
    }

    private void Update()
    {
        if (!isLit)
        {
             flame.gameObject.SetActive(false);
        }else if (isLit)
        {

            flame.gameObject.SetActive(true);
        }


        

    }

    private void Light()
    {
        
        isLit = true;
      
    }

    IEnumerator TTK()
    {
        if (playerHere == false && isLit == true)
        {
            yield return new WaitForSeconds(Duration);
            isLit = false;

        }
    }
}
