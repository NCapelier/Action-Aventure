using UnityEngine;
using Management;
using UnityEngine.Experimental.Rendering.Universal;
using Player;

namespace Lantern
{
    /// <summary>
    /// NCO - General management of the will o' the wisp object
    /// </summary>
    public class LanternManager : Singleton<LanternManager>
    {
        #region Variables

        // reference of the light object and its components
        [SerializeField] GameObject lightObject = null;
        Light2D mainLight = null;
        CircleCollider2D cc = null;

        // reference of the sprite mask object and its components
        [SerializeField] GameObject spriteMaskObject = null;
        SpriteMask sm = null;

        // light wiggle variables;
        float lightStartRadius = 0;

        #endregion

        void Awake()
        {
            MakeSingleton(false);
        }
        
        void Start()
        {
            //get all the required components of the light object and the mask object
            mainLight = lightObject.GetComponent<Light2D>();
            cc = lightObject.GetComponent<CircleCollider2D>();
            sm = spriteMaskObject.GetComponent<SpriteMask>();
            lightStartRadius = mainLight.pointLightOuterRadius;
        }
        
        void Update()
        {
            LightWiggle(20f, 0.0025f);
            UpdateComponentsRadius();
            UpdateLightRadius();
        }

        /// <summary>
        /// Makes the light wiggle
        /// </summary>
        void LightWiggle(float division, float step)
        {
            int upDown = Random.Range(0, 2);
            switch(upDown)
            {
                case 0:
                    if(mainLight.pointLightOuterRadius > lightStartRadius - lightStartRadius / division)
                    {
                        mainLight.pointLightOuterRadius -= step;
                    }
                    break;
                case 1:
                    if (mainLight.pointLightOuterRadius < lightStartRadius + lightStartRadius / division)
                    {
                        mainLight.pointLightOuterRadius += step;
                    }
                    break;
                default:
                    Debug.Log("Error, value is is out of boundaries !");
                    break;
            }
        }

        /// <summary>
        /// Synchronizes the collider's radius and the sprite mask with the light's radius
        /// </summary>
        void UpdateComponentsRadius()
        {
            cc.radius = mainLight.pointLightOuterRadius;
            sm.gameObject.transform.localScale = new Vector3(mainLight.pointLightOuterRadius * 0.05f, mainLight.pointLightOuterRadius * 0.05f, sm.gameObject.transform.localScale.z);
        }

        /// <summary>
        /// Sychronizes the inner light radius with the outer light radius
        /// </summary>
        void UpdateLightRadius()
        {
            mainLight.pointLightInnerRadius = mainLight.pointLightOuterRadius / 2;
        }

    }
}