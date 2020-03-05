using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Lantern
{
    /// <summary>
    /// NCO - Flash attack of the will of the wisp
    /// </summary>
    public class LanternFlashLight : MonoBehaviour
    {

        #region Variables

        //used for flash cooldown
        bool canFlash = true;

        //current state of the flash
        [HideInInspector] public flashState currentFlashState = flashState.Idle;

        // light2D component of the lantern
        Light2D lightComponent;

        // editor variables

        [Range(0f, 5f)]
        [SerializeField] float flashOuterRadius = 1f;

        [Range(0f, 50f)]
        [SerializeField] float flashSpeed = 1f;


        #endregion

        void Awake()
        {
            
        }
        
        void Start()
        {
            lightComponent = LanternManager.Instance.behaviour.GetComponent<Light2D>();
        }
        
        void Update()
        {
            switch(currentFlashState)
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
        }

        /// <summary>
        /// Called every frame when the light is not flashing
        /// </summary>
        void OnIdleUpdate()
        {
            if(LanternManager.Instance.boomerang.currentBoomerangState == boomerangState.Tidy)
            {
                canFlash = true;
            }
            if (Input.GetAxis("Left_Trigger") >= 0.8f && LanternManager.Instance.boomerang.currentBoomerangState != boomerangState.Tidy && canFlash)
            {
                canFlash = false;
                currentFlashState = flashState.FlashingUp;
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
                currentFlashState = flashState.Idle;
            }
        }

    }
}