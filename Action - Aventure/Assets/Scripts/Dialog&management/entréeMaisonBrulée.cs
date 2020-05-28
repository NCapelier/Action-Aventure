using UnityEngine;
using GameManagement;

public class entréeMaisonBrulée : MonoBehaviour
{
    [SerializeField] private Dialog.Conversation dialHelp1;

    private BoxCollider2D boxcol;

    

    // Start is called before the first frame update
    void Start()
    {
        boxcol = GetComponent<BoxCollider2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Instance.GetComponent<GameState>().potionGet == false)
        {
            GameCanvasManager.Instance.dialog.StartDialog = dialHelp1;
            boxcol.enabled = false;
            GameManager.Instance.GetComponent<GameState>().potionGet = true;


        }
     
    }
}
