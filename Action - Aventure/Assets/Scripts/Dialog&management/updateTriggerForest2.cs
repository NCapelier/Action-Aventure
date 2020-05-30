using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class updateTriggerForest2 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
     if(GameManager.Instance.gameState.cutSForet2 == true)
        {
            gameObject.SetActive(false);
        }   
    }
}
