﻿using UnityEngine;
using Management;

namespace Player
{
    /// <summary>
    /// NCO - General management of the Player object.
    /// </summary>
    public class PlayerManager : Singleton<PlayerManager>
    {

        public PlayerController controller = null;
        public PlayerContactAttack contactAttack = null;

        [HideInInspector] public int hp;

        [Range(1,50)]
        [SerializeField] int maxHp = 10;

        void Awake()
        {
            MakeSingleton(false);
        }

        void Start()
        {

        }


        void Update()
        {

        }

        void UpdateHp()
        {
            if (hp > maxHp)
            {
                hp = maxHp;
            }
            if (hp <= 0)
            {
                Death();
            }
        }

        void Death()
        {
            //death
        }

    }

}