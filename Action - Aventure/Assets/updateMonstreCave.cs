using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using GameManagement;

public class updateMonstreCave : MonoBehaviour
{

    private EnemyParent enemyParent;
    // Start is called before the first frame update

    private void Start()
    {
        enemyParent = GetComponent<EnemyParent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyParent.hp <= 0)
        {
            GameManager.Instance.gameState.enemyDone = true;
           
        }

        if(GameManager.Instance.gameState.enemyDone == true)
        {
            gameObject.SetActive(false);
        }
                
    }
}
