using UnityEngine;
using TMPro;

public class PotionsTextScript : MonoBehaviour
{
    private TextMeshProUGUI potionsText;
    public static int potionAmount;
    public static int maxPotionAmount;

    void Start()
    {
        potionsText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (potionAmount >= 0)
        { potionsText.text = potionAmount.ToString() + "/" + maxPotionAmount.ToString(); }


    }
}
