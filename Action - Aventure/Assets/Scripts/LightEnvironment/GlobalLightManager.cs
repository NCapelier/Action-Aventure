using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Management;

namespace LightEnvironment
{
    /// <summary>
    /// NCO - General management of the global light
    /// </summary>
    public class GlobalLightManager : Singleton<GlobalLightManager>
    {
        //Light 2D component of the object
        Light2D mainLight;
        
        //mainLight's min and max lighting
        [Range(0f, 1f)]
        [SerializeField] float minimumLighting = 0, maximumLightning = 1;

        //mainLight's increasing and decreasing speed
        [Range(0f, 10f)]
        [SerializeField] float increaseSpeed = 1, decreaseSpeed = 1;

        void Awake()
        {
            MakeSingleton(false);
        }
        
        void Start()
        {
            mainLight = gameObject.GetComponent<Light2D>();
            mainLight.intensity = maximumLightning;
        }

        void Update()
        {
            
        }
        
        /// <summary>
        /// Use this in update to increase the global light to its maximum
        /// </summary>
        void IncreaseGlobalLighting()
        {
            if(mainLight.intensity < maximumLightning)
            {
                mainLight.intensity += increaseSpeed * Time.deltaTime;
            }
        }

        /// <summary>
        /// Use this in update to decrease the global light to its minimum
        /// </summary>
        void DecreaseGlobalLighting()
        {
            if (mainLight.intensity > minimumLighting)
            {
                mainLight.intensity -= decreaseSpeed * Time.deltaTime;
            }
        }

    }
}