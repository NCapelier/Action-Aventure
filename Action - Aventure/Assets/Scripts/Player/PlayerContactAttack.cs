using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// NCO - Manages the player's contact attack
    /// </summary>
    public class PlayerContactAttack : MonoBehaviour
    {
        //attack params scripts
        [SerializeField] PlayerController controller = null;

        //attack conditions
        [HideInInspector] public bool isAttacking = false;

        Quaternion attackDirection;

        void Awake()
        {

        }

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetButtonDown("Right_Bumper") && !isAttacking)
            {
                Attack();
            }
        }

        /// <summary>
        /// Creates the Attack object
        /// </summary>
        GameObject Attack()
        {
            isAttacking = true;

            switch(controller.lastDirection)
            {
                case moveDirection.Top:
                    attackDirection = Quaternion.Euler(0, 0, 90);
                    break;
                case moveDirection.Down:
                    attackDirection = Quaternion.Euler(0, 0, -90);
                    break;
                case moveDirection.Right:
                    attackDirection = Quaternion.Euler(0, 0, 0);
                    break;
                case moveDirection.Left:
                    attackDirection = Quaternion.Euler(0, 0, 180);
                    break;
                default:
                    Debug.Log("Error, enum not assigned !");
                    break;
            }

            GameObject attack = (GameObject)Instantiate(Resources.Load("Prefabs/Player/Attack"), PlayerManager.Instance.transform.position, attackDirection);
            return attack;
        }

    }
}