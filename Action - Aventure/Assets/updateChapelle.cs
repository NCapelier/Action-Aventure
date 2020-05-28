
using UnityEngine;
using GameManagement;

public class updateChapelle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.gameState.chapelleTrigger == false)
        {
            GameManager.Instance.gameState.chapelleTrigger = true;

            GameManager.Instance.gameState.needToShow = false;
        }
       
    }
}

