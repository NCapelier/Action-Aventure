using UnityEngine;
using UnityEngine.UI;
using GameManagement;
using TMPro;

public class ZoneIntroduction : MonoBehaviour
{
    /// <summary>
    /// XP - This script makes the update of ZoneIntro Text according to the actual scene.
    /// </summary>


    public string zoneName;
    private string Scene_actu;

    public static int zoneIndex;

    public TextMeshProUGUI textComponent;


    public string[] zone;

  

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState.isDungeon == true)
        {
            //Cette asset la (monstre)
        }else if(GameManager.Instance.gameState.isDungeon == false)
        {
            //Celle ci (feuille)
        }


        //Updating the UI Text
        Scene_actu = zone[zoneIndex];
        zoneName = Scene_actu;
        textComponent.text = zoneName;
    }

}
