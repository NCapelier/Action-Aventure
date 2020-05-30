using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using GameManagement;

public class updateMonstreChapel1 : MonoBehaviour
{
    private EnemyParent enemyParent1;
    // Start is called before the first frame update

    private void Start()
    {
        enemyParent1 = GetComponent<EnemyParent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyParent1.hp <= 0)
        {
            GameManager.Instance.gameState.monstre1chapelle = true;

        }

        if (GameManager.Instance.gameState.monstre1chapelle == true)
        {
            gameObject.SetActive(false);
        }

    }
}
