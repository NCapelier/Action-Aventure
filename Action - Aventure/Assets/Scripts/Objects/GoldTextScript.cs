using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldTextScript : MonoBehaviour
{
    /// <summary>
    /// XP-Script to update amount of gold pickup by the player.
    /// </summary>

    private Text coinText;
    public static int coinAmount;
  
    void Start()
    {
        coinText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinAmount.ToString();
        
    }
}
