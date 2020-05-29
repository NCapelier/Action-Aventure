using UnityEngine;
using GameManagement;

public class triggerDoorChappel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            GameManager.Instance.gameState.ChapelleCutSceneFinish = true;
        }
    }



}

