using UnityEngine;
using GameManagement;

public class BlockerVillage : MonoBehaviour
{
    /// <summary>
    /// Block the player in the progression if he don't talk to the good person
    /// </summary>

    //Dialog reference
    public Dialog.Conversation dial1;
    public Dialog.Conversation dial2;
    public Dialog.Conversation dial3;

    public GameObject sceneTransition;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    private void Update()
    {
        if(GameManager.Instance.GetComponent<GameState>().firstDialogCM == true && GameManager.Instance.GetComponent<GameState>().firstDialogFC == true)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController")) {

            if (GameManager.Instance.GetComponent<GameState>().firstDialogCM == false && GameManager.Instance.GetComponent<GameState>().firstDialogFC == false)
            {
                GameCanvasManager.Instance.dialog.StartDialog = dial1;
                

            }
            else if (GameManager.Instance.GetComponent<GameState>().firstDialogCM == true && GameManager.Instance.GetComponent<GameState>().firstDialogFC == false)
            {
                GameCanvasManager.Instance.dialog.StartDialog = dial2;
                
            }
            else if (GameManager.Instance.GetComponent<GameState>().firstDialogCM == false && GameManager.Instance.GetComponent<GameState>().firstDialogFC == true)
            {
                GameCanvasManager.Instance.dialog.StartDialog = dial3;
               
            }
            

        }

        
    }


}
