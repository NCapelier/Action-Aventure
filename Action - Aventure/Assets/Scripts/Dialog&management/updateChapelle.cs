using UnityEngine;
using GameManagement;

public class updateChapelle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            if (GameManager.Instance.gameState.chapelleTrigger == false)
            {
                GameManager.Instance.gameState.chapelleTrigger = true;


                GameManager.Instance.gameState.needToShow = false;
            }

            if (GameManager.Instance.gameState.chapelleTrigger == true)
            {
                GameManager.Instance.gameState.needToShow = true;
            }
        }

    }
}

