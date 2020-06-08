using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class checkerEnnemies : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            GameManager.Instance.gameState.monstre1chapelle = true;
        }

        if (collision.gameObject.CompareTag("Enemy2"))
        {
            GameManager.Instance.gameState.monstre2chapelle = true;
        }

        if (collision.gameObject.CompareTag("Enemy3"))
        {
            GameManager.Instance.gameState.monstre3chapelle = true;
        }

        if (collision.gameObject.CompareTag("Enemy4"))
        {
            GameManager.Instance.gameState.enemyDone = true;
        }
    }
}
