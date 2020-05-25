using UnityEngine;
using Player;

namespace Enemy
{
    public class enemy2Attackbehaviour : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("PlayerController"))
            {
                PlayerManager.Instance.TakeDamages = 5;
            }
        }

    }
}