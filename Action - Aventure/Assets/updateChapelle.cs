
using UnityEngine;
using GameManagement;

public class updateChapelle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.gameState.chapelleTrigger = true;

        GameManager.Instance.gameState.needToShow = false;
    }
}

