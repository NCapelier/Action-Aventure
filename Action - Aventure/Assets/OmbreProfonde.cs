using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class OmbreProfonde : MonoBehaviour
{
  /// <summary>
  /// XP - This script makes the "ombre Profonde" disabled when the player get the Will'o
  /// </summary>
    void Update()
    {
        if (GameManager.Instance.GetComponent<GameState>().versatileGet  == true)
        {
            gameObject.SetActive(false);

        }
    }
}
