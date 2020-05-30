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
            if(!PlayerManager.Instance.invincible)
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
            SceneLoader.GoToScene("2_Forest_1", new Vector2(-8.8f, -12f));
        }
        public void GotoBurnedHouse()
        {
            //SceneLoader.GoToScene();
        }
        public void GotoDungeon()
        {
            //SceneLoader.GoToScene();
        }
        public void GotoBoss()
        {
            //SceneLoader.GoToScene();
        }
    }
}