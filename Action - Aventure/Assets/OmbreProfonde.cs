using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class OmbreProfonde : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetComponent<GameState>().versatileGet  == true)
        {
            gameObject.SetActive(false);

        }
    }
}
