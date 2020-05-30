using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using GameManagement;

public class updateMonstreChapel2 : MonoBehaviour
{
    private EnemyParent enemyParent2;
    // Start is called before the first frame update

    private void Start()
    {
        enemyParent2 = GetComponent<EnemyParent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyParent2.hp <= 0)
        {
            GameManager.Instance.gameState.monstre2chapelle = true;

        }

        if (GameManager.Instance.gameState.monstre2chapelle == true)
        {
            gameObject.SetActive(false);
        }

    }
}

