
using UnityEngine;
using GameManagement;

public class updateForet2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameManager.Instance.gameState.needToShow = true;
    }
}
