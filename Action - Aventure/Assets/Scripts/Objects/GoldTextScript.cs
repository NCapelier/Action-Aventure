using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldTextScript : MonoBehaviour
{
    /// <summary>
    /// XP-Script to update amount of gold pickup by the player.
    /// </summary>

    private TextMeshProUGUI coinText;
    public static int coinAmount;
  
    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinAmount.ToString();
    }
}
