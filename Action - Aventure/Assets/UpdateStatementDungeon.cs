using UnityEngine;
using GameManagement;

public class UpdateStatementDungeon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("playerController"))
        {
            GameManager.Instance.gameState.isDungeon = true;
        }
    }
}
