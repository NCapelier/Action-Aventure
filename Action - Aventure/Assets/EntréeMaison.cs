using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class EntréeMaison : MonoBehaviour
{
    [SerializeField] public Dialog.Conversation entréeMaison;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController")
        {
            GameCanvasManager.Instance.dialog.StartDialog = entréeMaison;
            gameObject.SetActive(false);
        }
    }
}
