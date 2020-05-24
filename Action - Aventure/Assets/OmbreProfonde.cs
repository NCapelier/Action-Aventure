using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class OmbreProfonde : MonoBehaviour
{
    /// <summary>
    /// XP - This script makes the "ombre Profonde" disabled when the player get the Will'o
    /// </summary
    /// 

    [SerializeField] public Dialog.Conversation ombreDial;

    void Update()
    {
       

        if (GameManager.Instance.GetComponent<GameState>().versatileGet  == true)
        {
            gameObject.SetActive(false);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            GameCanvasManager.Instance.dialog.StartDialog = ombreDial;
        }
    }
}
