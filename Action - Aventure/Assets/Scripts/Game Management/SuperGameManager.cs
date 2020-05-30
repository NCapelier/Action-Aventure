using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Lantern;
using GameSound;
using GameManagement;

namespace Management
{
    public class SuperGameManager : Singleton<SuperGameManager>
    {
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
    }
}