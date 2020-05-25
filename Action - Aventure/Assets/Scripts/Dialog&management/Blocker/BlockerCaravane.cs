using UnityEngine;
using GameManagement;

public class BlockerCaravane : MonoBehaviour
{
    /// <summary>
    /// XP - This script block the player if he don't have the lantern yet.
    /// </summary>*
 
    public Dialog.Conversation canPassThrought;

    private void Start()
    {
        GetComponent<SceneTransition>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Instance.GetComponent<GameState>().lanternGet == false)
        {
          

            GameCanvasManager.Instance.dialog.StartDialog = canPassThrought;

        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }



}
