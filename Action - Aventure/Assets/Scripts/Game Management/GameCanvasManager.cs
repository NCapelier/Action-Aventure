using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Management;
using Dialog;

namespace GameManagement
{
    public class GameCanvasManager : Singleton<GameCanvasManager>
    {

        public DialogDisplay dialog = null;

        void Awake()
        {
            MakeSingleton(false);
        }
    }
}