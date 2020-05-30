using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class BlockingCave : MonoBehaviour
{
    [SerializeField] private GameObject blockerGauche;
    [SerializeField] private GameObject blockerDroite;

    

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState.enemyDone == true)
        {

            gameObject.transform.position = blockerGauche.transform.position;
        }

        if(GameManager.Instance.gameState.enemyDone == false)
        {
            gameObject.transform.position = blockerDroite.transform.position;
        }
    }
}
