using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ZoneIntroduction : MonoBehaviour
{
    /// <summary>
    /// XP - This script makes the update of ZoneIntro Text according to the actual scene.
    /// </summary>
    /// 
    public string zoneName;
    private Scene Scene_actu;

    public TextMeshProUGUI textComponent;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Updating the UI Text
        Scene_actu = SceneManager.GetActiveScene();
        zoneName = Scene_actu.name;
        textComponent.text = "-    " + zoneName + "    -";
    }

   

   
}
