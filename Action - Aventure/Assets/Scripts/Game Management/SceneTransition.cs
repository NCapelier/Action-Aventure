using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace GameManagement
{
    public class SceneTransition : MonoBehaviour
    {

        [SerializeField] string nextScene = "";
        [SerializeField] Vector2 nextSceneEntryPoint = Vector2.zero;

        void Awake()
        {
            
        }
        
        void Start()
        {
            
        }
        
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "PlayerController")
            {
                SceneLoader.GoToScene(nextScene, nextSceneEntryPoint);
            }
        }

    }
}