using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSound;
using Player;
using LightEnvironment;

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

        bool playerCrazy = false;
        bool runningCrazyness = false;

        #endregion
        
        void Update()
        {
            if (Input.GetButtonDown("X_Button") && currentLightState == lightState.Displayed && LanternManager.Instance.boomerang.currentBoomerangState == boomerangState.Tidy
                && GlobalLightManager.Instance.mainLight.intensity >= GlobalLightManager.Instance.maximumLightning)
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
        }

        /// <summary>
        /// Called every frame when the light is hidden
        /// </summary>
        void OnHiddenUpdate()
        {
            if(!playerCrazy && !runningCrazyness)
            {
                playerCrazy = true;
                runningCrazyness = true;
                StartCoroutine(PlayerCrazyness());
            }

            if (Input.GetButtonUp("X_Button") && currentLightState == lightState.Hidden)
            {
                playerCrazy = false;
                EndHide();
            }

        }

        IEnumerator PlayerCrazyness()
        {
            yield return new WaitForSeconds(3f);
            if(playerCrazy == true)
            {
                PlayerManager.Instance.TakeDamages = 1;
                StartCoroutine(PlayerCrazyness());
            }
            else
            {
                runningCrazyness = false;
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
        }

    }
}