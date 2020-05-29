using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    /// <summary>
    /// NCO
    /// </summary>
    public class RockBehaviour : MonoBehaviour
    {
        [HideInInspector] public rockState currentRockState = rockState.Idle;

        public GameObject rockObject = null;

        bool spawnedRock = false;

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
                default:
                    break;
            }
        }

        void ShadowUpdate()
        {
            // --> animation apparition ombre
        }

        void RockUpdate()
        {
            // --> animation apparition rocher
            if(!spawnedRock)
            {
                spawnedRock = true;
                rockObject.SetActive(true);
            }
        }
    }
}