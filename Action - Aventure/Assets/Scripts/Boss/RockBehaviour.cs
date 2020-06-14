using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSound;

namespace Boss
{
    /// <summary>
    /// NCO
    /// </summary>
    public class RockBehaviour : MonoBehaviour
    {
        [HideInInspector] public rockState currentRockState = rockState.Idle;

        public GameObject shadowObject = null;
        public GameObject rockObject = null;

        bool spawnedRock = false;

        Animator shadowAnimator = null;

        Animator rockAnimator = null;

        private void Start()
        {
            shadowAnimator = shadowObject.GetComponent<Animator>();
            rockAnimator = rockObject.GetComponent<Animator>();
        }

        private void Update()
        {
            switch(currentRockState)
            {
                case rockState.Shadow:
                    ShadowUpdate();
                    break;
                case rockState.Rock:
                    RockUpdate();
                    break;
                case rockState.Idle:
                    IdleUpdate();
                    break;
                default:
                    break;
            }
        }

        void IdleUpdate()
        {
            if(spawnedRock)
            {
                spawnedRock = false;
            }
            if(rockObject.activeSelf)
            {
                rockObject.SetActive(false);
            }
            if(shadowAnimator.isActiveAndEnabled)
            {
                shadowAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                shadowAnimator.enabled = false;
            }
            if(rockAnimator.isActiveAndEnabled)
            {
                rockAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                rockAnimator.enabled = false;
            }
        }

        void ShadowUpdate()
        {
            if(!shadowAnimator.isActiveAndEnabled)
            {
                shadowAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                shadowAnimator.enabled = true;
            }
        }

        void RockUpdate()
        {


            if (!spawnedRock)
            {
                spawnedRock = true;
                rockObject.SetActive(true);
                //
                AudioManager.Instance.Play("Rock_impact");
            }

            // --> animation apparition rocher
            if (!rockAnimator.isActiveAndEnabled)
            {
                rockAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = true;

                rockAnimator.enabled = true;

                AudioManager.Instance.Play("Rock_fall");
            }
        }
    }
}