using System.Collections;
using UnityEngine;
using Player;

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

        // editor variables

        [Range(0f, 5f)]
        [SerializeField] float castCooldown = 1;

        [Range(0f, 5f)]
        [SerializeField] float castTime = 1;

        [Range(0f, 1000f)]
        [SerializeField] float castSpeed = 1;

        [Range(0f, 1000f)]
        [SerializeField] float fallBackSpeed = 1;

        [Range(0f, 10f)]
        [SerializeField] float catchRange = 1;

        // right joystick inputs
        float horizontal = 0, vertical = 0;

        // used to stop the movement of the lantern and swith to the next boomerang state
        [HideInInspector] public bool mustStop = false;

        // used for cast cooldown
        bool canCast = true;

        #endregion

        void Awake()
        {

        }

        void Start()
        {
            lanternRb = LanternManager.Instance.GetComponent<Rigidbody2D>();
            LanternManager.Instance.gameObject.transform.SetParent(PlayerManager.Instance.gameObject.transform);
        }

        void Update()
        {
            switch (currentBoomerangState)
            {
                case boomerangState.Tidy:
                    OnTidyUpdate();
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

        /// <summary>
        /// Called every frame when the lantern is tidy
        /// </summary>
        void OnTidyUpdate()
        {
            LanternManager.Instance.gameObject.transform.position = PlayerManager.Instance.gameObject.transform.position;
            if (Input.GetButtonDown("Left_Bumper") && canCast && LanternManager.Instance.hideLight.currentLightState == lightState.Displayed)
            {
                Cast();
            }
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
            }
        }

        /// <summary>
        /// Called every frame when the lantern is static out of the player
        /// </summary>
        void OnStaticUpdate()
        {
            if (Input.GetButtonDown("Left_Bumper"))
            {
                FallBack();
            }
        }

        /// <summary>
        /// Called every frame when the lantern is falling back
        /// </summary>
        void OnFallBackUpdate()
        {
            lanternRb.velocity = (PlayerManager.Instance.transform.position - LanternManager.Instance.gameObject.transform.position).normalized * fallBackSpeed * Time.deltaTime;
            if(Vector2.Distance(LanternManager.Instance.transform.position, PlayerManager.Instance.transform.position) < catchRange)
            {
                LanternManager.Instance.gameObject.transform.SetParent(PlayerManager.Instance.gameObject.transform);
                StartCoroutine(CastCooldown());
                currentBoomerangState = boomerangState.Tidy;
            }
        }

        /// <summary>
        /// Casts the Lantern
        /// </summary>
        void Cast()
        {
            horizontal = Input.GetAxis("Right_Joystick_X");
            vertical = -Input.GetAxis("Right_Joystick_Y");

            if ((horizontal < -0.15 || horizontal > 0.15 || vertical < -0.15 || vertical > 0.15) && currentBoomerangState == boomerangState.Tidy)
            {
                currentBoomerangState = boomerangState.Cast;
                canCast = false;
                aimDirection = new Vector2(horizontal, vertical);
                LanternManager.Instance.gameObject.transform.SetParent(null);
                StartCoroutine(CastLifeTime());
                lanternRb.velocity = aimDirection.normalized * castSpeed * Time.deltaTime;
            }
        }

        /// <summary>
        /// duration of the cast of the light
        /// </summary>
        /// <returns></returns>
        IEnumerator CastLifeTime()
        {
            yield return new WaitForSeconds(castTime);
            if (currentBoomerangState == boomerangState.Cast)
            {
                lanternRb.velocity = Vector2.zero;
                currentBoomerangState = boomerangState.Static;
            }
        }

        /// <summary>
        /// Falls back the lantern
        /// </summary>
        void FallBack()
        {
            currentBoomerangState = boomerangState.FallBack;
        }

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