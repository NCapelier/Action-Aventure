using System.Collections;
using UnityEngine;
using Player;
using UnityEngine.UI;
using GameSound;
using GameManagement;

namespace Lantern
{
    /// <summary>
    /// NCO - Boomerang attack : Cast and FallBack
    /// </summary>
    public class LanternBoomerang : MonoBehaviour
    {

        #region Variables

        // boomerang cast direction
        Vector2 aimDirection = Vector2.zero;

        // current states of the boomerang
        [HideInInspector] public boomerangState currentBoomerangState = boomerangState.Tidy;

        //rigidbody2D of the lantern
        Rigidbody2D lanternRb = null;

        //lantern ui canvas
        Canvas uiCanvas = null;

        //loading image
        Image loadingBar = null;

        //current loading of the cast
        [HideInInspector] public float loading = 0f;

        [SerializeField] SpriteRenderer lanternSprite = null;
        [SerializeField] GameObject lanternParticle = null;

        // editor variables

        [Range(0f, 5f)]
        [SerializeField] float castCooldown = 1;

        [Range(0f, 1000f)]
        [SerializeField] float castSpeed = 1;

        [Range(0f, 1000f)]
        [SerializeField] float fallBackSpeed = 1;

        [Range(0f, 10f)]
        [SerializeField] float catchRange = 1;

        [Range(0f, 50f)]
        [SerializeField] float maxLoad = 10f;

        [Range(0f, 10f)]
        [SerializeField] float loadingSpeed = 1f;

        // right joystick inputs
        float horizontal = 0, vertical = 0;

        // used to stop the movement of the lantern and swith to the next boomerang state
        [HideInInspector] public bool mustStop = false;

        // used for cast cooldown
        bool canCast = true;

        //position of the boomerang before being casted
        Vector2 castOrigin = Vector2.zero;

        //Sound
        AudioSource flightSound;
        #endregion


        void Start()
        {
            //get all referenced components
            lanternRb = LanternManager.Instance.GetComponent<Rigidbody2D>();
            uiCanvas = GetComponentInChildren<Canvas>();
            loadingBar = GetComponentInChildren<Image>();
            LanternManager.Instance.gameObject.transform.SetParent(PlayerManager.Instance.gameObject.transform);

            uiCanvas.worldCamera = Camera.main;

            flightSound = AudioManager.Instance.GetSound("Will_o_flight");
        }

        void FixedUpdate()
        {
            UpdateAimDistance();
            switch (currentBoomerangState)
            {
                case boomerangState.Tidy:
                    OnTidyUpdate();
                    break;
                case boomerangState.PreCast:
                    //OnPreCastUpdate();
                    break;
                case boomerangState.Cast:
                    OnCastUpdate();
                    break;
                case boomerangState.Static:
                    OnStaticUpdate();
                    break;
                case boomerangState.FallBack:
                    OnFallBackUpdate();
                    break;
                default:
                    Debug.Log("Error, value is not assigned !");
                    break;
            }
        }

        private void Update()
        {
            //D.Log(this.name + " --> " + loading);

            if (currentBoomerangState == boomerangState.Tidy && lanternSprite.enabled)
            {
                lanternSprite.enabled = false;
                lanternParticle.SetActive(false);
            }
            else if (currentBoomerangState != boomerangState.Tidy && !lanternSprite.enabled)
            {
                lanternSprite.enabled = true;
                lanternParticle.SetActive(true);
            }

            if (PlayerManager.Instance.controller.isDialoging)
                return;

            if (currentBoomerangState == boomerangState.Tidy)
            {
                if (!GameManager.Instance.gameState.versatileGet)
                    return;

                if (Input.GetButton("Left_Bumper") && canCast && LanternManager.Instance.hideLight.currentLightState == lightState.Displayed && LanternManager.Instance.flashLight.currentLightStrength == lightStrength.Strengthful)
                {
                    currentBoomerangState = boomerangState.PreCast;
                }
            }
            else if(currentBoomerangState == boomerangState.PreCast)
            {
                LanternManager.Instance.gameObject.transform.position = PlayerManager.Instance.gameObject.transform.position;
                if ((Input.GetButtonUp("Left_Bumper")/* || !Input.GetButton("Left_Buper")*/) && canCast && LanternManager.Instance.hideLight.currentLightState == lightState.Displayed)
                {
                    Cast();
                    return;
                }
                if (canCast && LanternManager.Instance.hideLight.currentLightState == lightState.Displayed && loading < maxLoad)
                {
                    loading += loadingSpeed * Time.deltaTime;
                }
                else if (loading >= maxLoad)
                {
                    Cast();
                }
                else
                {
                    loading = 0f;
                    currentBoomerangState = boomerangState.Tidy;
                    return;
                }
            }
            else if(currentBoomerangState == boomerangState.Static)
            {
                if (Input.GetButtonDown("Left_Bumper"))
                {
                    currentBoomerangState = boomerangState.FallBack;

                    //Sound
                    flightSound.Play();
                }
            }
            

        }

        void UpdateAimDistance()
        {
            PlayerManager.Instance.aimBehaviour.aimObject.transform.localPosition = new Vector3(loading.Remap(0f, maxLoad, 0.5f, 2f), 0, 0);
        }

        /// <summary>
        /// Called every frame when the lantern is tidy
        /// </summary>
        void OnTidyUpdate()
        {
            if (!GameManager.Instance.gameState.lanternGet)
                return;

            LanternManager.Instance.gameObject.transform.position = PlayerManager.Instance.gameObject.transform.position;

        }

        void OnPreCastUpdate()
        {


            //loadingBar.fillAmount = loading.Remap(0f, maxLoad, 0f, 1f);
;
        }

        void Cast()
        {
            canCast = false;

            horizontal = Input.GetAxis("Right_Joystick_X");
            vertical = -Input.GetAxis("Right_Joystick_Y");
            if (horizontal < -0.15 || horizontal > 0.15 || vertical < -0.15 || vertical > 0.15)
            {
                aimDirection = new Vector2(horizontal, vertical).normalized;
            }
            else
            {
                currentBoomerangState = boomerangState.Tidy;
                loading = 0f;
                canCast = true;
                return;
            }
            LanternManager.Instance.gameObject.transform.SetParent(null);
            // todo : new movement depending on loading
            castOrigin = LanternManager.Instance.gameObject.transform.position;

            lanternRb.velocity = aimDirection.normalized * castSpeed;
            mustStop = false;
            currentBoomerangState = boomerangState.Cast;

            //Sound
            flightSound.Play();
        }

        /// <summary>
        /// Called every frame when the lantern is casted
        /// </summary>
        void OnCastUpdate()
        {
            if (mustStop)
            {
                mustStop = false;
                lanternRb.velocity = Vector2.zero;
                currentBoomerangState = boomerangState.Static;
                loading = 0f;

                //Sound
                flightSound.Stop();
            }
            if(Vector2.Distance(castOrigin, LanternManager.Instance.gameObject.transform.position) >= loading)
            {
                mustStop = true;
                loading = 0f;
            }
        }

        /// <summary>
        /// Called every frame when the lantern is static out of the player
        /// </summary>
        void OnStaticUpdate()
        {

        }

        /// <summary>
        /// Called every frame when the lantern is falling back
        /// </summary>
        void OnFallBackUpdate()
        {
            lanternRb.velocity = (PlayerManager.Instance.transform.position - LanternManager.Instance.gameObject.transform.position).normalized * fallBackSpeed;
            if(Vector2.Distance(LanternManager.Instance.transform.position, PlayerManager.Instance.transform.position) < catchRange)
            {
                LanternManager.Instance.gameObject.transform.SetParent(PlayerManager.Instance.gameObject.transform);
                StartCoroutine(CastCooldown());
                currentBoomerangState = boomerangState.Tidy;

                //Sound
                flightSound.Stop();
            }
        }

        /// <summary>
        /// duration of the cast of the light
        /// </summary>
        /// <returns></returns>
        /*IEnumerator CastLifeTime()
        {
            yield return new WaitForSeconds(castTime);
            if (currentBoomerangState == boomerangState.Cast)
            {
                lanternRb.velocity = Vector2.zero;
                currentBoomerangState = boomerangState.Static;
            }
        }*/

        /// <summary>
        /// Cooldown before to be able to cast the boomerang again after catching it
        /// </summary>
        /// <returns></returns>
        IEnumerator CastCooldown()
        {
            yield return new WaitForSeconds(castCooldown);
            canCast = true;
        }

    }
}