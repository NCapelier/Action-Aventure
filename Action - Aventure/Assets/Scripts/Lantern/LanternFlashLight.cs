using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using GameSound;
using GameManagement;

namespace Lantern
{
    /// <summary>
    /// NCO - Flash attack of the will of the wisp
    /// </summary>
    public class LanternFlashLight : MonoBehaviour
    {

        #region Variables

        //used for flash cooldown
        [HideInInspector] public bool canFlash = true;

        //current state of the flash
        [HideInInspector] public flashState currentFlashState = flashState.Idle;

        //current strength of the light
        [HideInInspector] public lightStrength currentLightStrength = lightStrength.Strengthful;

        // light2D component of the lantern
        Light2D lightComponent;

        // editor variables

        [Range(0f, 5f)]
        [SerializeField] float flashOuterRadius = 1f;

        [Range(0f, 50f)]
        [SerializeField] float flashSpeed = 1f;

        [HideInInspector] public bool mustRegerenate = false;

        #endregion
        
        void Start()
        {
            lightComponent = LanternManager.Instance.behaviour.GetComponent<Light2D>();
        }
        
        void Update()
        {
            if (!GameManager.Instance.gameState.versatileGet)
                return;
            switch (currentFlashState)
            {
                case flashState.Idle:
                    OnIdleUpdate();
                    break;
                case flashState.FlashingUp:
                    OnFlashUpUpdate();
                    break;
                case flashState.FlashingDown:
                    OnFlashDownUpdate();
                    break;
                default:
                    Debug.Log("Error, value is not assigned !");
                    break;
            }

            switch(currentLightStrength)
            {
                case lightStrength.Strengthful:
                    break;
                case lightStrength.Weakening:
                    OnWeakeningUpdate();
                    break;
                case lightStrength.Weak:
                    OnWeakUpdate();
                    break;
                case lightStrength.Recovering:
                    OnRecoveringUpdate();
                    break;
                default:
                    Debug.Log("Error, value is not assigned !");
                    break;
            }
        }

        #region Flash State Methods

        /// <summary>
        /// Called every frame when the light is not flashing
        /// </summary>
        void OnIdleUpdate()
        {
            if (Input.GetAxis("Left_Trigger") >= 0.8f && canFlash && currentLightStrength == lightStrength.Strengthful)
            {
                canFlash = false;
                currentFlashState = flashState.FlashingUp;
                currentLightStrength = lightStrength.Weakening;


                //Sound
                AudioManager.Instance.Play("Flash");
            }
        }

        /// <summary>
        /// Called every frame when the flash is starting
        /// </summary>
        void OnFlashUpUpdate()
        {
            if(lightComponent.pointLightOuterRadius < flashOuterRadius)
            {
                lightComponent.pointLightOuterRadius += flashSpeed * Time.deltaTime;
            }
            else
            {
                currentFlashState = flashState.FlashingDown;

                //Sound
                AudioManager.Instance.Play("Will_o_exting");
            }
        }

        /// <summary>
        /// Called every frame when the flash is stopping
        /// </summary>
        void OnFlashDownUpdate()
        {
            if (lightComponent.pointLightOuterRadius > LanternManager.Instance.behaviour.lightStartRadius)
            {
                lightComponent.pointLightOuterRadius -= flashSpeed * Time.deltaTime;
            }
            else
            {
                currentLightStrength = lightStrength.Weakening;
                currentFlashState = flashState.Idle;
            }
        }

        #endregion

        [Range(0f,10f)]
        [SerializeField] float weakOuterRadius = 1.0f;

        [Range(0f, 50f)]
        [SerializeField] float weakeningSpeed = 1.0f;

        [Range(0f, 50f)]
        [SerializeField] float recoveringSpeed = 1.0f;


        #region Light Strength State Methods

        void OnWeakeningUpdate()
        {
            if(lightComponent.pointLightOuterRadius > weakOuterRadius)
            {
                lightComponent.pointLightOuterRadius -= weakeningSpeed * Time.deltaTime;
            }
            else
            {
                currentLightStrength = lightStrength.Weak;
            }
        }

        void OnWeakUpdate()
        {
            currentLightStrength = lightStrength.Recovering;
        }

        void OnRecoveringUpdate()
        {
            if (lightComponent.pointLightOuterRadius < LanternManager.Instance.behaviour.lightStartRadius)
            {
                lightComponent.pointLightOuterRadius += recoveringSpeed * Time.deltaTime;
            }
            else
            {
                canFlash = true;
                currentLightStrength = lightStrength.Strengthful;
                return;
            }
            if (mustRegerenate)
            {
                mustRegerenate = false;
                lightComponent.pointLightOuterRadius = LanternManager.Instance.behaviour.lightStartRadius;
                canFlash = true;
                currentLightStrength = lightStrength.Strengthful;
            }
        }


        #endregion

    }
}