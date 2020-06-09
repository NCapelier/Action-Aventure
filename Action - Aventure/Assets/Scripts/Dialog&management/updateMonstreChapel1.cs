using UnityEngine;
using GameManagement;

public class updateMonstreChapel1 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
      
        if (GameManager.Instance.gameState.monstre1chapelle == true)
        {
            gameObject.SetActive(false);
        }

    }
}
