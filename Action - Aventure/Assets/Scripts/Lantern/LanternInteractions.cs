﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lantern
{
    /// <summary>
    /// NCO - Manages the lantern's collider
    /// </summary>
    public class LanternInteractions : MonoBehaviour
    {
        
        
        
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
            if(collision.CompareTag("Wall"))
            {
                LanternManager.Instance.boomerang.mustStop = true;
            }
            if(collision.CompareTag("Enemy"))
            {
                //deal damages to the enemy
                //

                if(LanternManager.Instance.flashLight.currentFlashState == flashState.FlashingUp)
                {
                    //stuns the enemy
                }
            }
        }

    }
}