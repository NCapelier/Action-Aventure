using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Enemy2Movement : MonoBehaviour
    {
        //XP This code make the behavior of the Enemy 2 Behaviour

        //Target - All this stuff is use to set the target
        public GameObject waypoints;
        private Transform target;
        private int waypointIndex = 0;
        public GameObject player;
        public int attackDirection;
        public int direction;
        public bool playerFound;

        //Velocity
        public Rigidbody2D rb;
        public float speed = 10f;

        //distance - Set the distance of Swaping Target
        public float enterPlayerArea = 2f;
        public float distanceToSwitchTargetWaypoints = 0.5f;
        public float ennemiRangeAttack;

        //Clock - Use to make the enemy walk clock
        public bool clockOneEnded;
        public bool clockTwoEnded;
        public bool playerNotFound;

        //Camera - Use for Camera shake
        public CameraShake cameraShake;

        //Attaque - All Variables use for attack
        public float attackSpeed;
        public bool canAttack;
        public float warningTime;
        public bool isAttacking;
        public float immobilizationTime;
        public Vector3 move;

        //Zone de dégats  - Zone de Dégats
        public GameObject LeftAttack;
        public GameObject RightAttack;
        public GameObject UpAttack;
        public GameObject DownAttack;

    public int numberofWaypointsMax;


    private void Start()
    {
        //At the beggining of the script Je set la target sur le waypoint à l'index 0 de mon tableau.

            target = waypoints.GetComponent<GetWaypoints>().points[0];

            clockTwoEnded = true;

            playerNotFound = true;

            rb = GetComponent<Rigidbody2D>();

            canAttack = true;

            rb.velocity = new Vector3(0, 0, 0);

            LeftAttack.SetActive(false);
            RightAttack.SetActive(false);
            UpAttack.SetActive(false);
            DownAttack.SetActive(false);

            playerFound = false;

        }

        private void Update()
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

                //je change la velocité
                rb.velocity = dir.normalized * speed * Time.deltaTime;

                //Quand le player est en zone d'attaque
                if (Vector2.Distance(transform.position, player.transform.position) >= ennemiRangeAttack)
                {
                    //scren Shake
                    //StartCoroutine(cameraShake.Shake(.01f, .05f));
                }

            }
            else if (Vector2.Distance(transform.position, player.transform.position) >= enterPlayerArea)    //Dans le cas ou le player pas dans la zone d'aggro.
            {
                playerFound = false;
                //Debug.Log("Player Outside");

                //Alors mon ennemi se déplace vers les waypoints
                target = waypoints.GetComponent<GetWaypoints>().points[waypointIndex];

                //Début de la clock (Déplacement => Arret => Déplacement => Arret.
                if (clockTwoEnded == true)
                {
                    rb.velocity = dir.normalized * speed * Time.deltaTime;
                    clockOne();

                }
                //Start clocktwo
                else if (clockOneEnded == true && playerFound == false)
                {
                    ///j'arrete l'ennemi pour simuler que son pied tombe sur le sol comme un sumo



                    if (Vector2.Distance(transform.position, player.transform.position) >= ennemiRangeAttack)
                    {
                        if (playerFound == true)
                        {
                            StartCoroutine(cameraShake.Shake(.05f, .05f));
                        }
                    }

                    rb.velocity = new Vector3(0, 0, 0);
                    clockTwo();


                }

                //Quand mon ennemi est arrivé à destination 
                if (Vector2.Distance(transform.position, target.position) <= distanceToSwitchTargetWaypoints)
                {
                    //Changement d'aggro
                    GetNextWaypoints();
                }
            }


            //Check la distance d'aggro.
            if (Vector2.Distance(transform.position, player.transform.position) <= ennemiRangeAttack)
            {
                rb.velocity = new Vector3(0, 0, 0);

                //Attaque
                StartCoroutine(Attack());

                if (isAttacking == true)
                {   //Je bloque l'ennemi
                    rb.velocity = new Vector3(0, 0, 0);
                }
            }

        }

        private void GetNextWaypoints()
        {
            waypointIndex++;

            //Si on a fini la boucle, on recommence à 0 (je suis obligé de mettre n+1 waypoints car sinon je sors du tableau et ça casse tout
            if (waypointIndex == 5)
            {
                waypointIndex = 0;
            }

            target = waypoints.GetComponent<GetWaypoints>().points[waypointIndex];

        }

        //Si on a fini la boucle, on recommence à 0 (je suis obligé de mettre n+1 waypoints car sinon je sors du tableau et sa casse tout
        if (waypointIndex == 5)
        {
            StartCoroutine(Clock1());
        }

        private void clockTwo()
        {
            StartCoroutine(Clock2());
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

            //LA C'EST JUSTE DES MATHS
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

                yield return new WaitForSeconds(attackSpeed);

                canAttack = true;

            }
        }
    }
}

