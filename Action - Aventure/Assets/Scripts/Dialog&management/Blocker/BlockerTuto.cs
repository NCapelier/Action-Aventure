using UnityEngine;
using GameManagement;


public class BlockerTuto : MonoBehaviour
{
    //Dialog Lines
    [SerializeField] private Dialog.Conversation needPotion;

    // Start is called before the first frame update
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.GetComponent<GameState>().potionGet == false)
        {
 
            GameCanvasManager.Instance.dialog.StartDialog = needPotion;
            


        }
        if(GameManager.Instance.GetComponent<GameState>().potionGet == true)
        {
            gameObject.SetActive(false);
            
        }
    }

}
