using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Lantern;
using GameSound;
using GameManagement;
using UnityEngine.SceneManagement;

namespace Management
{
    public class SuperGameManager : Singleton<SuperGameManager>
    {

        [HideInInspector] public bool video = false;

        private void Awake()
        {
            MakeSingleton(true);
        }
        public void DestroyAllGameObjects()
        {
            Destroy(CameraManager.Instance.gameObject);
            Destroy(PlayerManager.Instance.gameObject);
            Destroy(LanternManager.Instance.gameObject);
            Destroy(GameManager.Instance.gameObject);
            Destroy(AudioManager.Instance.gameObject);
        }

        private void Update()
        {
            if(SceneManager.GetActiveScene().name == "0_MainMenu")
            {
                Destroy(GameManager.Instance.gameObject);
            }
        }
    }
}