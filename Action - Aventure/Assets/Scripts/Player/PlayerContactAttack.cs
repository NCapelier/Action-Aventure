using UnityEngine;

namespace Player
{
    /// <summary>
    /// NCO - Manages the player's contact attack
    /// </summary>
    public class PlayerContactAttack : MonoBehaviour
    {

        #region Variables

        //attack conditions
        [HideInInspector] public bool isAttacking = false;

        //direction of the attack (Top, Down, Left or Right)
        Quaternion attackDirection;

        //aim quaternion
        PlayerAimBehaviour aimBehaviour;

        //attack damages
        [HideInInspector] public float loading = 0f;

        //editor variables :

        [Range(0f,50f)]
        [SerializeField] float maxLoad = 10f;

        [Range(0f, 10f)]
        [SerializeField] float loadingSpeed = 1f;

        #endregion

        void Awake()
        {

        }

        void Start()
        {
            aimBehaviour = PlayerManager.Instance.aimBehaviour;
        }

        void Update()
        {
            AttackInput();
        }

        void AttackInput()
        {
            if(!isAttacking)
            {
                if (Input.GetButton("Right_Bumper") && loading < maxLoad)
                {
                    loading += loadingSpeed;
                }

                if (Input.GetButtonUp("Right_Bumper"))
                {
                    Attack();
                }
            }
        }

        /// <summary>
        /// Summons the Attack object
        /// </summary>
        GameObject Attack()
        {
            isAttacking = true;

            /*switch(PlayerManager.Instance.controller.lastDirection)
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
            }*/

            attackDirection = aimBehaviour.orientationQuaternion;

            GameObject attack = (GameObject)Instantiate(Resources.Load("Prefabs/Player/Attack"), PlayerManager.Instance.transform.position, attackDirection);
            return attack;
        }

    }
}