using Management;
using UnityEngine;
using Dialog;

namespace GameManagement
{
    public class GameCanvasManager : Singleton<GameCanvasManager>
    {

        public DialogDisplay dialog = null;
        public ConsoleManager console = null;

        void Awake()
        {
            MakeSingleton(false);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Back_Button"))
            {
                if(console.gameObject.activeSelf)
                {
                    console.gameObject.SetActive(false);
                }
                else
                {
                    console.gameObject.SetActive(true);
                }
            }

        }
    }
}