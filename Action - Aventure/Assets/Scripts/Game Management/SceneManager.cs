using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Management;

namespace GameManagement
{
    public class SceneManager : Singleton<SceneManager>
    {
        #region Variables

        Scene activeScene;

        [SerializeField] string[] allScenes = null;

        #endregion

        void Awake()
        {
            MakeSingleton(true);
        }
        
        void Start()
        {
            
        }
        
        void Update()
        {
            activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

            switch(activeScene.name)
            {
                case "NCO_Scene_01":
                    NCO_Scene_01Update();
                    break;
                case "NCO_Scene_02":
                    NCO_Scene_02Update();
                    break;
                default:
                    Debug.Log("Error, scene does not exist in SceneManager");
                    break;
            }
        }

        void NCO_Scene_01Update()
        {

        }

        void NCO_Scene_02Update()
        {

        }

    }
}