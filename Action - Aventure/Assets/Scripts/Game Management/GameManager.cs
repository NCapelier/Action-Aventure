﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Management;

namespace GameManagement
{
    /// <summary>
    /// NCO - General management of the game.
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {



        void Awake()
        {
            MakeSingleton(true);
        }

        void Start()
        {

        }


        void Update()
        {

        }



    }
}