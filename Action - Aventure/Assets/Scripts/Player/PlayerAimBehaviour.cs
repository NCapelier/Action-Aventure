using System.Collections;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// NCO - Makes this object's orientation depend on the right joystick input
    /// </summary>
    public class PlayerAimBehaviour : MonoBehaviour
    {
        public enum aimDeadZone { True, False};
        #region Variables

        //temp current aim display pattern used
        //aimDeadZone aimState = aimDeadZone.True;

        //right joystick input
        [HideInInspector] public float horizontal = 0, vertical = 0;

        // current orientation of the right vector in V3 and Q
        [HideInInspector] public Vector3 orientationVector = Vector3.zero;
        [HideInInspector] public Quaternion orientationQuaternion;

        //aim sprite
        [SerializeField] SpriteRenderer aimSprite = null;

        #endregion

        void Awake()
        {

        }

        void Start()
        {

        }

        void Update()
        {
            Rotate();
        }

        /// <summary>
        /// Rotates the object depending on the right joystick input
        /// </summary>
        void Rotate()
        {
            horizontal = Input.GetAxis("Right_Joystick_X");
            vertical = -Input.GetAxis("Right_Joystick_Y");

            if (horizontal < -0.15 || horizontal > 0.15 || vertical < -0.15 || vertical > 0.15)
            {
                aimSprite.enabled = true;
                orientationVector = new Vector3(0, 0, Mathf.Atan2(vertical, horizontal) * 180 / Mathf.PI);
                orientationQuaternion = Quaternion.Euler(orientationVector);
                gameObject.transform.rotation = orientationQuaternion;
            }
            else
            {
                aimSprite.enabled = false;
            }
        }

    }
}