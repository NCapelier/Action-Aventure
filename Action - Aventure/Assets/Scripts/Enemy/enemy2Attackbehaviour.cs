using UnityEngine;
using Player;
using GameManagement;

namespace Enemy
{
    public class enemy2Attackbehaviour : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (GameManager.Instance.gameState.playerDead)
                return;
            if (collision.CompareTag("PlayerController"))
            {
                PlayerManager.Instance.TakeDamages = 2;
            }
        }

    }
}