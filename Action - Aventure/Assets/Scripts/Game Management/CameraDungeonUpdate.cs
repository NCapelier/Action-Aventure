using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class CameraDungeonUpdate : MonoBehaviour
{
    [SerializeField] private GameObject roomCam;

    // Start is called before the first frame update
    void Awake()
    {
        if (GameManager.Instance.gameState.isDungeon == true)
        {
            Camera.main.enabled = false;
            roomCam.SetActive(true);
        }
    }

   
}
