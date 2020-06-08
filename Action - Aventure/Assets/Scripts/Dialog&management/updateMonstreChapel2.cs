using UnityEngine;
using GameManagement;

public class updateMonstreChapel2 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.gameState.monstre2chapelle == true)
        {
            gameObject.SetActive(false);
        }

    }
}

