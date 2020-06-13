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
        public bool runningCrazyness = false;

        AudioSource chatteringTeeth;

        float time = 6f;

        [HideInInspector] public float displayTime = 1;

        #endregion

        private void Start()
        {
            chatteringTeeth = AudioManager.Instance.GetSound("Chattering_teeth");
        }

        void Update()
        {
            if (!GameManager.Instance.gameState.lanternGet)
                return;


            displayTime = time.Remap(0f, 6f, 0f, 1f);

            if(PlayerManager.Instance.potionBottles.inDrinkUnhideMalus)
            {
                PlayerManager.Instance.potionBottles.inDrinkUnhideMalus = false;
                if(currentLightState == lightState.Hidden)
                {
                    EndHide();
                }
            }

            if (currentLightState == lightState.Hidden && PlayerManager.Instance.currentHp <= 1)
            {
                EndHide();
            }

            if (currentLightState == lightState.Displayed && time < PlayerManager.Instance.currentHp)
            {
                time += 1.0f * Time.deltaTime;
            }
            else if (time > PlayerManager.Instance.currentHp)
            {
                time = PlayerManager.Instance.currentHp;
            }

            if (Input.GetButtonDown("X_Button") && currentLightState == lightState.Displayed && LanternManager.Instance.boomerang.currentBoomerangState == boomerangState.Tidy
                && GlobalLightManager.Instance.mainLight.intensity >= GlobalLightManager.Instance.maximumLightning && PlayerManager.Instance.controller.isDialoging == false)
            {
                StartHide();
            }
            else if (currentLightState == lightState.Hidden/* || (playerCrazy && PlayerManager.Instance.potionBottles.inDrinkUnhideMalus)*/)
            {
                OnHiddenUpdate();
            }
            //else if (playerCrazy && PlayerManager.Instance.potionBottles.inDrinkUnhideMalus)
            //{
            //    EndHide();
            //}

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
            chatteringTeeth.PlayDelayed(0.9f);
        }

        /// <summary>
        /// Called every frame when the light is hidden
        /// </summary>
        void OnHiddenUpdate()
        {
            if (!playerCrazy && !runningCrazyness && !PlayerManager.Instance.potionBottles.inDrinkUnhideMalus)
            {
                playerCrazy = true;
                runningCrazyness = true;
                //StartCoroutine(PlayerCrazyness());
            }
            else if (playerCrazy && PlayerManager.Instance.potionBottles.inDrinkUnhideMalus)
            {
                StopCoroutine(PlayerCrazyness());
                EndHide();
                return;
            }

            if (Input.GetButtonUp("X_Button"))
            {

                EndHide();
                return;
            }

            if (time <= 0)
            {
                PlayerManager.Instance.TakeDamages = 1;
                EndHide();
            }
            else
            {
                time -= 1f * Time.deltaTime;
            }

        }

        IEnumerator PlayerCrazyness()
        {
            yield return new WaitForSeconds(3f);
            if (playerCrazy == true)
            {
                PlayerManager.Instance.TakeDamages = 1;
                EndHide();
            }
        }

        /// <summary>
        /// Displays the light
        /// </summary>
        void EndHide()
        {
            playerCrazy = false;
            runningCrazyness = false;
            LanternManager.Instance.interaction.gameObject.SetActive(true);
            currentLightState = lightState.Displayed;
            //time = PlayerManager.Instance.currentHp;


            //Sound
            AudioManager.Instance.Play("Coat_open");
            chatteringTeeth.Stop();
        }

    }
}