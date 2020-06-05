using System.Collections;
using UnityEngine;
using GameSound;
using Player;
using LightEnvironment;
using GameManagement;

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

        public bool playerCrazy = false;
        bool runningCrazyness = false;

        AudioSource chatteringTeeth;
        #endregion

        private void Start()
        {
            chatteringTeeth = AudioManager.Instance.GetSound("Chattering_teeth");
        }

        void Update()
        {
            if (!GameManager.Instance.gameState.lanternGet)
                return;
            if (Input.GetButtonDown("X_Button") && currentLightState == lightState.Displayed && LanternManager.Instance.boomerang.currentBoomerangState == boomerangState.Tidy
                && GlobalLightManager.Instance.mainLight.intensity >= GlobalLightManager.Instance.maximumLightning && PlayerManager.Instance.controller.isDialoging == false)
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
            if(!playerCrazy && !runningCrazyness)
            {
                playerCrazy = true;
                runningCrazyness = true;
                StartCoroutine(PlayerCrazyness());
            }

            if (Input.GetButtonUp("X_Button"))
            {
                
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
            playerCrazy = false;
            LanternManager.Instance.interaction.gameObject.SetActive(true);
            currentLightState = lightState.Displayed;

            //Sound
            AudioManager.Instance.Play("Coat_open");
            chatteringTeeth.Stop();
        }

    }
}