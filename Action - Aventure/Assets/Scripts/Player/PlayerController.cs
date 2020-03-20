using System.Collections;
using UnityEngine;
using Lantern;

namespace Player
{
    /// <summary>
    /// Player's 4 possible movement directions
    /// </summary>
    [HideInInspector] public enum moveDirection { Top, Down, Left, Right };


    /// <summary>
    /// NCO - Manages all the player's movement and dash interactions.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        #region Variables

        // editor variables : player's movement variables
        [Range(0.1f, 500f)]
        [SerializeField] float movementSpeed = 1;

        [Range(0.1f, 2000f)]
        [SerializeField] float dashSpeed = 1;

        [Range(0f, 5f)]
        [SerializeField] float dashDuration = 0.1f;

        [Range(0f, 10f)]
        [SerializeField] float dashCooldown = 2f;

        // Player rigidbody2D
        Rigidbody2D playerRb;

        // all booleans about the player's movement states
        bool isMoving = false, isAttacking = false, isDashing = false;

        /// <summary>
        /// --> GA - Stores the last movement direction depending on the moveDirection enum
        /// </summary>
        [HideInInspector] public moveDirection lastDirection;

        // movement direction variables
        float horizontal = 0, vertical = 0;
        Vector2 movementVector = Vector2.zero, dashVector = Vector2.zero;
        [HideInInspector] public Vector2 computedVelocity = Vector2.zero;
        [HideInInspector] public Vector2 computedMovementVector = Vector2.zero;

        #endregion

        void Start()
        {
            playerRb = PlayerManager.Instance.GetComponent<Rigidbody2D>();
        }


        void Update()
        {
            isAttacking = PlayerManager.Instance.contactAttack.isAttacking;
            MoveInput();
            DashInput();
            Move();
            UpdateMoveState();
        }

        /// <summary>
        /// Stores the input of the player's movement into the movementVector variable
        /// </summary>
        void MoveInput()
        {
            horizontal = Input.GetAxis("Left_Joystick_X");
            vertical = -Input.GetAxis("Left_Joystick_Y");

            if ((horizontal < -0.15 || horizontal > 0.15 || vertical < -0.15 || vertical > 0.15) && !isAttacking /*&& !isDashing*/ )
            {
                isMoving = true;
                movementVector = new Vector2(horizontal, vertical);
            }
            else
            {
                isMoving = false;
                movementVector = Vector2.zero;
            }
        }

        /// <summary>
        /// Stores the input of the player's dash into the dashVector variable
        /// </summary>
        void DashInput()
        {
            if (Input.GetAxis("Left_Trigger") >= 0.8f && !isDashing && !isAttacking && LanternManager.Instance.flashLight.canFlash)
            {
                isDashing = true;
                dashVector = movementVector;
                StartCoroutine(DashDuration());
            }
            else if(isAttacking)
            {
                isDashing = false;
                dashVector = Vector2.zero;
            }
        }

        /// <summary>
        /// Ends the dash after dashTime seconds
        /// </summary>
        /// <returns></returns>
        IEnumerator DashDuration()
        {
            yield return new WaitForSeconds(dashDuration);
            isDashing = false;
            dashVector = Vector2.zero;
        }

        /// <summary>
        /// Stores the combined movements and apply them to the player's rigidbody2D
        /// </summary>
        void Move()
        {
            if(movementVector.magnitude > 1)
            {
                computedMovementVector = movementVector.normalized;
            }
            else
            {
                computedMovementVector = movementVector;
            }

            computedVelocity = ((computedMovementVector * movementSpeed) + (dashVector.normalized * dashSpeed)) * Time.deltaTime;
            playerRb.velocity = computedVelocity;
        }

        /// <summary>
        /// Updates the current direction of the Player (in 4 directions) in the lastDirection value
        /// </summary>
        void UpdateMoveState()
        {
            if (isMoving)
            {
                if (horizontal.isBetween(0, true, 1, true) && vertical.isBetween(0, false, 1, true))
                {
                    if (Mathf.Abs(horizontal) >= Mathf.Abs(vertical))
                    {
                        lastDirection = moveDirection.Right;
                    }
                    else
                    {
                        lastDirection = moveDirection.Top;
                    }
                }
                else if (horizontal.isBetween(-1, true, 0, false) && vertical.isBetween(0, true, 1, true))
                {
                    if (Mathf.Abs(horizontal) >= Mathf.Abs(vertical))
                    {
                        lastDirection = moveDirection.Left;
                    }
                    else
                    {
                        lastDirection = moveDirection.Top;
                    }
                }
                else if (horizontal.isBetween(-1, true, 0, false) && vertical.isBetween(-1, true, 0, true))
                {
                    if (Mathf.Abs(horizontal) >= Mathf.Abs(vertical))
                    {
                        lastDirection = moveDirection.Left;
                    }
                    else
                    {
                        lastDirection = moveDirection.Down;
                    }
                }
                else if (horizontal.isBetween(0, true, 1, true) && vertical.isBetween(-1, true, 0, false))
                {
                    if (Mathf.Abs(horizontal) >= Mathf.Abs(vertical))
                    {
                        lastDirection = moveDirection.Right;
                    }
                    else
                    {
                        lastDirection = moveDirection.Down;
                    }
                }
                else
                {
                    Debug.Log("Error, value is is out of boundaries !");
                }
            }
        }
    }
}