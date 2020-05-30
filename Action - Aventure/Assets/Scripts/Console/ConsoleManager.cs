using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace GameManagement
{
    public class ConsoleManager : MonoBehaviour
    {
        public void GetLantern()
        {
            GameManager.Instance.gameState.lanternGet = true;
        }
        public void GetWOTW()
        {
            GameManager.Instance.gameState.versatileGet = true;
        }
        public void GetPotions()
        {
            GameManager.Instance.gameState.potionGet = true;
        }

        public void ToggleInvincibility()
        {
            if (!PlayerManager.Instance.invincible)
            {
                PlayerManager.Instance.invincible = true;
            }
            else
            {
                PlayerManager.Instance.invincible = false;
            }
        }
        public void KillAllEnemiesInScene()
        {
            //
        }

        public void GotoTown()
        {
            SceneLoader.GoToScene("3_Town", new Vector2(-5.5f, -4.5f));
        }
        public void GotoBurnedHouse()
        {
            SceneLoader.GoToScene("4_BurnedHouse", new Vector2(1.4f, 4.5f));
        }
        public void GotoDungeon()
        {
            SceneLoader.GoToScene("Room1", new Vector2(-0.5f, -7.5f));
        }
        public void GotoBoss()
        {
            SceneLoader.GoToScene("Boss3", new Vector2(0f, -12f));
        }
    }
}