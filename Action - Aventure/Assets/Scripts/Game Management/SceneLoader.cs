using UnityEngine;
using UnityEngine.SceneManagement;
using Management;
using Player;
using Lantern;
using GameManagement;

namespace GameManagement
{
    public enum SceneEntry { Left, Right, Top, Bottom, Bottom_Left, Bottom_Right};

    public class SceneLoader : Singleton<SceneLoader>
    {
        #region Variables
       
        #endregion

        void Awake()
        {
            MakeSingleton(true);
        }


        /// <summary>
        /// Teleports the player to the next scene
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="entryPoint"></param>
        public static Scene GoToScene(string scene, Vector2 entryPoint)
        {
              bool cameraActive = false;

            if(GameManager.Instance.cameraPlayer.activeSelf == true)
            {
                CameraManager.Instance.vCam.enabled = false;
                cameraActive = true;
            }
            
            SceneManager.LoadScene(scene);
            //mettre du delay?
            PlayerManager.Instance.transform.position = entryPoint;
            LanternManager.Instance.transform.position = entryPoint;

            if (cameraActive == true)
            {
                CameraManager.Instance.vCam.enabled = true;
                cameraActive = false;
            }
            
            return SceneManager.GetActiveScene();
        }
    }
}