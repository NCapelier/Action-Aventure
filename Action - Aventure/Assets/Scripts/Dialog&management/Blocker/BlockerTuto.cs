using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;


public class BlockerTuto : MonoBehaviour
{

    [SerializeField] private Dialog.Conversation needPotion;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SceneTransition>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.GetComponent<GameState>().potionGet == false)
        {
 
            GameCanvasManager.Instance.dialog.StartDialog = needPotion;

        }
        else
        {
            GetComponent<SceneTransition>().enabled = true;
        }
    }

}
