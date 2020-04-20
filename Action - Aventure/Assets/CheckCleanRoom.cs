using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCleanRoom : MonoBehaviour
{
    [SerializeField] private GameObject enemyMaster;
    [SerializeField] private GameObject door;

    public GameObject[] ennemies;

    // Start is called before the first frame update
    void Start()
    {
        ennemies = enemyMaster.GetChildrenWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(ennemies[0] = null)
        {
            Debug.Log("finito");
            door.SetActive(false);
        }
    }
}
