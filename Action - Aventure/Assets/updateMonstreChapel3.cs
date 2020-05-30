using UnityEngine;
using GameManagement;

public class updateMonstreChapel3 : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
       

        if (GameManager.Instance.gameState.monstre3chapelle == true)
        {
            gameObject.SetActive(false);
        }

    }
}
