using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Manages all the player's movement interactions.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        // Player speed
        [Range(0.1f, 15f)]
        [SerializeField] float speed = 1;

        void Awake()
        {

        }

        void Start()
        {

        }


        void Update()
        {
            Move();
        }

        /// <summary>
        /// Moves the Player object depending on the left joystick's direction.
        /// </summary>
        void Move()
        {
            float horizontal = Input.GetAxisRaw("Left_Joystick_X");
            float vertical = -Input.GetAxisRaw("Left_Joystick_Y");
            if((horizontal < -0.1 || horizontal > 0.1) || (vertical < -0.1 || vertical > 0.1))
            {
                //PlayerManager.Instance.transform.Translate(new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime);
                PlayerManager.Instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontal, vertical).normalized * speed * Time.deltaTime);
            }
        }

    }
}