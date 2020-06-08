using UnityEngine;
using GameSound;
using GameManagement;
using System.Collections;

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
        [HideInInspector] public float loading = 1f;

        //editor variables :

        [Range(0f, 50f)]
        [SerializeField] float maxLoad = 10f;

        [Range(0f, 10f)]
        [SerializeField] float loadingSpeed = 1f;

        //Animator 
        public GameObject fxSprite;
        public Animator fxAnim;

        [HideInInspector] public bool canAttack = true;

        [HideInInspector] public bool routine = false;

        #endregion

        void Start()
        {
            aimBehaviour = PlayerManager.Instance.aimBehaviour;
        }

        void FixedUpdate()
        {
            if (!GameManager.Instance.gameState.lanternGet)
                return;
            AttackInput();
        }

        private void Update()
        {
            if (!GameManager.Instance.gameState.lanternGet)
                return;
            if (Input.GetButtonUp("Right_Bumper") && !isAttacking && canAttack && PlayerManager.Instance.controller.isDialoging == false)
            {
                Attack();
            }
            if(routine)
            {
                routine = false;
                StartCoroutine(Cooldown());
            }
        }

        void AttackInput()
        {
            if (!GameManager.Instance.gameState.lanternGet)
                return;

            if (!isAttacking && canAttack)
            {
                if (Input.GetButton("Right_Bumper") && loading < maxLoad)
                {
                    loading += loadingSpeed;
                }
                if(loading >= maxLoad)
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
            canAttack = false;

            //Animation
            PlayerManager.Instance.controller.anim.SetFloat("AttackX", PlayerManager.Instance.aimBehaviour.horizontal);
            PlayerManager.Instance.controller.anim.SetFloat("AttackY", PlayerManager.Instance.aimBehaviour.vertical);
            PlayerManager.Instance.controller.AttackAnimation();
            //fxAnim.SetBool("isAttacking", true);

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

            PlayAttackSound();

            GameObject attack = (GameObject)Instantiate(Resources.Load("Prefabs/Player/Attack"), PlayerManager.Instance.transform.position + new Vector3(0f, 0.5f), attackDirection);
            //PlayerManager.Instance.controller.fxAnim = attack.GetComponent<PlayerAttackBehaviour>().spriteObject.GetComponent<Animator>();
            return attack;
        }

        public IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(0.5f);
            canAttack = true;
        }

        void PlayAttackSound()
        {
            if(loading < maxLoad * 0.30f)
            {
                AudioManager.Instance.Play("Lantern_light_strike");
            }
            else
            {
                AudioManager.Instance.Play("Lantern_charged_strike");
            }
        }
    }
}