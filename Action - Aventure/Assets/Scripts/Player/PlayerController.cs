using System.Collections;
using UnityEngine;
using Lantern;
using GameSound;

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

        //[Range(0f, 10f)]
        //[SerializeField] float dashCooldown = 2f;

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

        // Animator
        [HideInInspector] public Animator anim;
        //[HideInInspector] public GameObject fxSprite;
        [HideInInspector] public Animator fxAnim = null;

        //Sound
        private AudioSource WalkSound;
        bool walkPlaying = false;
        private AudioSource DashSound;
        bool runPlaying = false;
        #endregion

        void Start()
        {
            playerRb = PlayerManager.Instance.GetComponent<Rigidbody2D>();
            anim = gameObject.GetComponent<Animator>();
            //fxAnim = fxSprite.GetComponent<Animator>();
            WalkSound = AudioManager.Instance.GetSound("Walking");
            DashSound = AudioManager.Instance.GetSound("Running");
        }


        void Update()
        {
            isAttacking = PlayerManager.Instance.contactAttack.isAttacking;
            MoveInput();
            DashInput();
            Move();
            //UpdateMoveState();
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
                
                //Animation
                anim.SetBool("isMoving", true);
                anim.SetFloat("MovementX", horizontal);
                anim.SetFloat("MovementY", vertical);

                //Sound
                if (!walkPlaying)
                {
                    WalkSound.Play();
                    walkPlaying = true;
                }
            }
            else
            {
                isMoving = false;
                movementVector = Vector2.zero;

                //Animation
                anim.SetBool("isMoving", false);

                //Sound
                WalkSound.Stop();
                walkPlaying = false;

            }
        }

        /// <summary>
        /// Stores the input of the player's dash into the dashVector variable
        /// </summary>
        void DashInput()
        {
            if (Input.GetAxis("Left_Trigger") >= 0.8f && !isDashing && !isAttacking && LanternManager.Instance.flashLight.canFlash && LanternManager.Instance.boomerang.currentBoomerangState == boomerangState.Tidy)
            {
                isDashing = true;
                dashVector = movementVector;
                StartCoroutine(DashDuration());

                //Animation
                anim.SetBool("isRunning", true);

                //Sound
                WalkSound.Stop();

                if (!runPlaying)
                {
                    DashSound.Play();
                    runPlaying = true;
                }
            }
            else if(isAttacking)
            {
                isDashing = false;
                dashVector = Vector2.zero;

                //Sound
                DashSound.Stop();
                runPlaying = false;
            }

            if (isDashing)
            {
                dashVector = movementVector;
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

            //Animation
            anim.SetBool("isRunning", false);

            //Sound
            DashSound.Stop();
            runPlaying = false;
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
        /*void UpdateMoveState()
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
        }*/

        /// <summary>
        /// Play animations for the player
        /// </summary>
        public void DeathAnimation()
        {
            anim.SetBool("isDead", true);
        }
       
        public void FallAnimation()
        {
            anim.SetBool("isFall", true);
        }
        /// <summary>
        /// Play the animation of Attack 
        /// </summary>
        public void AttackAnimation()
        {
            anim.SetBool("isAttacking", true);
        }

        //Hit Animation
        public void HitAnimation()
        {
            anim.SetBool("isHit", true);
        }

        // Get Animation Event
        public void GetAnimationEvent(string EventMessage)
        {
            if (EventMessage.Equals("AttackEnded"))
            {
                anim.SetBool("isAttacking", false);
            }
           
            if (EventMessage.Equals("BigAttackEnded"))
            {
                anim.SetBool("isBigAttack", false);
            }

            if (EventMessage.Equals("Hit"))
            {
                anim.SetBool("isHit", false);
            }
        }
    }
}