using UnityEngine;
using GameManagement;

public class UpdateStatementDungeon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            GameManager.Instance.gameState.isDungeon = true;
            GameManager.Instance.gameState.needToShow = true;
        }
    }
}
