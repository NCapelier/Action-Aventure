﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Enemy
{
    public class Enemy2Fixe : MonoBehaviour
    {
        //Target - All this stuff is use to set the target
        public GameObject waypointFixe;
        private Transform target;
        public GameObject player;
        private int direction;
        public float ennemiRangeAttack;
        private int attackDirection;
        private bool playerFound;

        //Velocity
        private Rigidbody2D rb;
        public float speed = 10f;
        private Vector3 move;


        //distance - Set the distance of Swaping Target
        public float enterPlayerArea;

        //Attaque
        public float attackSpeed;
        private bool canAttack;
        public float warningTime;
        private bool isAttacking;
        public float immobilizationTime;

        //Zone de dégats
        public GameObject LeftAttack;
        public GameObject RightAttack;
        public GameObject UpAttack;
        public GameObject DownAttack;

        //Camera - Use for Camera shake
        //public CameraShake cameraShake;


        //Clock - Use to make the enemy walk clock
        private bool clockOneEnded;
        private bool clockTwoEnded;

        //Animation
        private Animator anim = null;
        private Animator eyeAnim = null;
        public GameObject Animator;
        public GameObject EyesAnimator;

        // Start is called before the first frame update
        void Start()
        {
            player = PlayerManager.Instance.gameObject;

            target = waypointFixe.transform;

            rb = GetComponent<Rigidbody2D>();

            canAttack = true;

            //Animation
            anim.SetFloat("Xmovement", rb.velocity.x);
            anim.SetFloat("Ymovement", rb.velocity.y);
            anim.SetBool("isMoving", true);
            //Animation Eyes
            eyeAnim.SetFloat("Xmovement", rb.velocity.x);
            eyeAnim.SetFloat("Ymovement", rb.velocity.y);
            eyeAnim.SetBool("isMoving", true);

            LeftAttack.SetActive(false);
            RightAttack.SetActive(false);
            UpAttack.SetActive(false);
            DownAttack.SetActive(false);

            playerFound = false;

            clockTwoEnded = true;
        }

        // Update is called once per frame
        void Update()
        {

            //Permet de créer le vecteur pour la target
            Vector2 dir = target.position - transform.position;

            //Permet de check la position du player tout le temps.
            Direction();

            //Dans le cas ou le player est dans la zone d'aggro
            if (Vector2.Distance(transform.position, player.transform.position) <= enterPlayerArea)
            {
                playerFound = true;
                //Debug.Log("playerFound");

                //Switch de target de waypoints à player.
                target = player.transform;
                //je change la velocité pour déplacer l'ennemi
                rb.velocity = dir.normalized * speed * Time.deltaTime;
                if (Vector2.Distance(transform.position, player.transform.position) >= ennemiRangeAttack)
                {
                    //StartCoroutine(cameraShake.Shake(.05f, .05f));
                }

            }
            else if (Vector2.Distance(transform.position, player.transform.position) >= enterPlayerArea)

            {
                playerFound = false;
                //Debug.Log("Player Outside");

                //Alors mon ennemi se déplace vers le waypoint
                target = waypointFixe.transform;

                if (clockTwoEnded == true)
                {
                    rb.velocity = dir.normalized * speed * Time.deltaTime;
                    clockOne();
                }

                //Start clocktwo
                else if (clockOneEnded == true && playerFound == false)
                {

                    rb.velocity = new Vector3(0, 0, 0);


                    /*if (Vector2.Distance(transform.position, player.transform.position) >= ennemiRangeAttack)
                    {
                        StartCoroutine(cameraShake.Shake(.05f, .05f));
                    }
                    clockTwo();*/
                }

            }

            if (Vector2.Distance(transform.position, player.transform.position) <= ennemiRangeAttack)
            {
                rb.velocity = new Vector3(0, 0, 0);
                StartCoroutine(Attack());

                if (isAttacking == true)
                {
                    rb.velocity = new Vector3(0, 0, 0);
                }
            }

            if (Vector2.Distance(transform.position, waypointFixe.transform.position) <= 0.1 && playerFound == false)
            {
                rb.velocity = new Vector3(0, 0, 0);
            }

            //Debug.Log(direction);
        }




        private void clockOne()
        {
            StartCoroutine("Clock1");
        }

        private void clockTwo()
        {
            StartCoroutine("Clock2");
        }

        IEnumerator Clock1()
        {
            clockTwoEnded = false;
            yield return new WaitForSecondsRealtime(0.5f);
            clockOneEnded = true;
            //Debug.Log("clockOne Move");
        }
        //Stop Mouvement
        IEnumerator Clock2()
        {
            clockOneEnded = false;
            yield return new WaitForSecondsRealtime(0.5f);
            clockTwoEnded = true;
            //Debug.Log("clockTwo Move");
        }
        void Direction()
        {
            move = (player.transform.position - transform.position).normalized;

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

                //Animation
                anim.SetBool("isAttacking", true);
                eyeAnim.SetBool("isAttacking", true);

                rb.velocity = new Vector3(0, 0, 0);
                yield return new WaitForSeconds(warningTime);

                switch (direction)
                {
                    case 0:
                        //Debug.Log("Attaque Haute");
                        UpAttack.SetActive(true);
                        break;
                    case 1:
                        //Debug.Log("Attaque Droite");
                        RightAttack.SetActive(true);
                        break;
                    case 2:
                        //Debug.Log("Attaque En bas");
                        DownAttack.SetActive(true);
                        break;
                    case 3:
                        //Debug.Log("Attaque Gauche");
                        LeftAttack.SetActive(true);
                        break;
                    default:
                        break;
                }

                yield return new WaitForSeconds(0.001f);


                yield return new WaitForSeconds(immobilizationTime);

                LeftAttack.SetActive(false);
                RightAttack.SetActive(false);
                UpAttack.SetActive(false);
                DownAttack.SetActive(false);
                isAttacking = false;
                
                //Animation
                anim.SetBool("isAttacking", false);
                eyeAnim.SetBool("isAttacking", false);

                yield return new WaitForSeconds(attackSpeed);

                canAttack = true;

            }
        }

    }
}