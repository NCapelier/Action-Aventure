using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lantern
{
    /// <summary>
    /// NCO - Hides the will of the wisp
    /// </summary>
    public class LanternHideLight : MonoBehaviour
    {

        #region Variables

        [HideInInspector] public lightState currentLightState = lightState.Displayed;

        #endregion

        void Awake()
        {
            
        }
        
        void Start()
        {
            
        }
        
        void Update()
        {
            if (Input.GetButtonDown("X_Button") && currentLightState == lightState.Displayed && LanternManager.Instance.boomerang.currentBoomerangState == boomerangState.Tidy)
            {
                StartHide();
            }
            if(currentLightState == lightState.Hidden)
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
        }

    }
}