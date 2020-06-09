using UnityEngine;
using GameManagement;

public class updateMonstreCave : MonoBehaviour
{
    void Update()
    {

        if(GameManager.Instance.gameState.enemyDone == true)
        {
            gameObject.SetActive(false);
        }
                
    }
}
