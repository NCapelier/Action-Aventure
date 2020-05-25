﻿using UnityEngine;

namespace GameManagement
{
    public class SceneTransition : MonoBehaviour
    {

        [SerializeField] string nextScene = "";
        [SerializeField] Vector2 nextSceneEntryPoint = Vector2.zero;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "PlayerController")
            {
                SceneLoader.GoToScene(nextScene, nextSceneEntryPoint);
                ZoneScripter.isTrigger = true;
            }
        }

    }
}