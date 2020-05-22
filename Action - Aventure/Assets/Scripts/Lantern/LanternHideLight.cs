﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSound;

namespace Lantern
{
    /// <summary>
    /// NCO - Hides the will of the wisp
    /// </summary>
    public class LanternHideLight : MonoBehaviour
    {

        #region Variables

        // current light display state
        [HideInInspector] public lightState currentLightState = lightState.Displayed;

        AudioSource chatteringTeeth;
        #endregion

        private void Start()
        {
            chatteringTeeth = AudioManager.Instance.GetSound("Chattering_teeth");
        }

        void Update()
        {
            if (Input.GetButtonDown("X_Button") && currentLightState == lightState.Displayed && LanternManager.Instance.boomerang.currentBoomerangState == boomerangState.Tidy)
            {
                StartHide();
            }
            else if(currentLightState == lightState.Hidden)
            {
                OnHiddenUpdate();
            }
        }
        
        /// <summary>
        /// Hides the light
        /// </summary>
        void StartHide()
        {
            LanternManager.Instance.interaction.gameObject.SetActive(false);
            currentLightState = lightState.Hidden;

            //Sound
            AudioManager.Instance.Play("Coat_close");
            chatteringTeeth.Play();
        }

        /// <summary>
        /// Called every frame when the light is hidden
        /// </summary>
        void OnHiddenUpdate()
        {
            if(Input.GetButtonUp("X_Button") && currentLightState == lightState.Hidden)
            {
                EndHide();
            }

        }

        /// <summary>
        /// Displays the light
        /// </summary>
        void EndHide()
        {
            LanternManager.Instance.interaction.gameObject.SetActive(true);
            currentLightState = lightState.Displayed;

            //Sound
            AudioManager.Instance.Play("Coat_open");
            chatteringTeeth.Stop();
        }

    }
}