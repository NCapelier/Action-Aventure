using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;


public class updateCameraBoss : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            CameraManager.Instance.vCam.enabled = true;
            GameManager.Instance.gameOverMenu.SetActive(true);
        }
    }
  
    

}
