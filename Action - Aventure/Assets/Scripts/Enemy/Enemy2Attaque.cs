using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Enemy2Attaque : MonoBehaviour
    {
        //Target
        public GameObject player;
        public int direction;
        public float ennemiRangeAttack;
        public int attackDirection;

        //Déplacement
        public Rigidbody2D rbEnemy;
        public float speed;
        public Vector3 move;
        public Vector3 velocity;


        //Attaque
        public float attackSpeed;
        public float freezeTime;
        public bool canAttack;
        private float warningTime;
        public bool isAttacking;
        public float immobilizationTime;

        void Start()
        {

            rbEnemy = GetComponent<Rigidbody2D>();
        }

        void Update()
        {

            /*if (Vector2.Distance(transform.position, player.transform.position) <= ennemiRangeAttack)
            {
                rbEnemy.velocity = new Vector3(0, 0, 0);

                StartCoroutine(Attack());
            }*/
        }

        void Direction()
        {
            if (move != Vector3.zero)
            {
                if (move.y >= Mathf.Sqrt(2) / 2 && move.x <= Mathf.Sqrt(2) / 2 && move.x >= -Mathf.Sqrt(2) / 2)
                {
                    direction = 0;        //up
                }
                else if (move.y <= -Mathf.Sqrt(2) / 2 && move.x <= Mathf.Sqrt(2) / 2 && move.x >= -Mathf.Sqrt(2) / 2)
                {
                    direction = 2;        //down               
                }
                else if (move.x >= Mathf.Sqrt(2) / 2 && move.y <= Mathf.Sqrt(2) / 2 && move.y >= -Mathf.Sqrt(2) / 2)
                {
                    direction = 1;        //right                
                }
                else if (move.x <= -Mathf.Sqrt(2) / 2 && move.y <= Mathf.Sqrt(2) / 2 && move.y >= -Mathf.Sqrt(2) / 2)
                {
                    direction = 3;        //left 
                }
            }
        }


        IEnumerator Attack()
        {
            if (canAttack == true)
            {

                canAttack = false;
                isAttacking = true;
                attackDirection = direction;

                yield return new WaitForSeconds(warningTime);

                switch (attackDirection)
                {
                    case 0:
                        Debug.Log("Attaque Haute");
                        //Activer la zone de dégats En haut
                        break;
                    case 1:
                        Debug.Log("Attaque Droite");
                        //Activer la zone de dégats Right
                        break;
                    case 2:
                        Debug.Log("Attaque En bas");
                        //Activer la zone de dégats Down
                        break;
                    case 3:
                        Debug.Log("Attaque Gauche");
                        //Activer la zone de dégats Left
                        break;
                    default:
                        break;
                }

                yield return new WaitForSeconds(0.001f);

                yield return new WaitForSeconds(immobilizationTime);

                isAttacking = false;

                yield return new WaitForSeconds(attackSpeed);

                canAttack = true;

            }
        }

    }
}