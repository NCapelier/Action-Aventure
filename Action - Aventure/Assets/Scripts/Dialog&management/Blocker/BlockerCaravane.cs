using UnityEngine;
using GameManagement;

public class BlockerCaravane : MonoBehaviour
{
    /// <summary>
    /// XP - This script block the player if he don't have the lantern yet.
    /// </summary>*
 
    public Dialog.Conversation canPassThrought;

    
    private void Update()
    {
        if (GameManager.Instance.GetComponent<GameState>().lanternGet == true)
        {

            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Instance.GetComponent<GameState>().lanternGet == false)
        {
          

            GameCanvasManager.Instance.dialog.StartDialog = canPassThrought;

        }

    }



}
