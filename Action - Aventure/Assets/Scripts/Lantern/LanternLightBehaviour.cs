using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Lantern
{
    /// <summary>
    /// NCO - Behaviour of the will of the wisp's light
    /// </summary>
    public class LanternLightBehaviour : MonoBehaviour
    {
        #region Variables

        // reference to components of the light object
        Light2D mainLight = null;
        CircleCollider2D cc = null;

        // reference to sprite mask component
        SpriteMask sm = null;

        // light wiggle variables
        [HideInInspector] public float lightStartRadius = 0;

        #endregion

        void Awake()
        {

        }

        void Start()
        {
            //get all the required components of the light object and the mask object
            mainLight = GetComponent<Light2D>();
            cc = GetComponent<CircleCollider2D>();
            sm = LanternManager.Instance.spriteMaskObject.GetComponent<SpriteMask>();
            lightStartRadius = mainLight.pointLightOuterRadius;
        }

        void Update()
        {
            if(LanternManager.Instance.flashLight.currentFlashState == flashState.Idle)
            {
                LightWiggle(20f, 0.002f);
            }
            UpdateComponentsRadius();
            UpdateLightRadius();
        }

        /// <summary>
        /// Makes the light wiggle
        /// </summary>
        void LightWiggle(float division, float step)
        {
            if(LanternManager.Instance.flashLight.currentLightStrength == lightStrength.Strengthful)
            {
                int upDown = Random.Range(0, 2);
                switch (upDown)
                {
                    case 0:
                        if (mainLight.pointLightOuterRadius > lightStartRadius - lightStartRadius / division)
                        {
                            mainLight.pointLightOuterRadius -= step * Time.deltaTime;
                        }
                        break;
                    case 1:
                        if (mainLight.pointLightOuterRadius < lightStartRadius + lightStartRadius / division)
                        {
                            mainLight.pointLightOuterRadius += step * Time.deltaTime;
                        }
                        break;
                    default:
                        Debug.Log("Error, value is is out of boundaries !");
                        break;
                }
            }
        }

        /// <summary>
        /// Synchronizes the collider's radius and the sprite mask with the light's radius
        /// </summary>
        void UpdateComponentsRadius()
        {
            //cc.radius = mainLight.pointLightOuterRadius;
            sm.gameObject.transform.localScale = new Vector3(mainLight.pointLightOuterRadius * 0.05f, mainLight.pointLightOuterRadius * 0.05f, sm.gameObject.transform.localScale.z);
        }

        /// <summary>
        /// Sychronizes the inner light radius with the outer light radius
        /// </summary>
        void UpdateLightRadius()
        {
            mainLight.pointLightInnerRadius = mainLight.pointLightOuterRadius * 0.5f;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Wall"))
            {

            }
        }

    }
}