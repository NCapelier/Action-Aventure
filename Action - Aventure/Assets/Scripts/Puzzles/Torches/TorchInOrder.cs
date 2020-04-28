using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Puzzle
{
    /// <summary>
    /// CHB -- Torch to be lit if a specific one is already lit. Possibilty for limited time before the previous is put out
    /// </summary>
    public class TorchInOrder : Torch
    {
        #region Variables
        [SerializeField] private GameObject prev;
        private Torch prevTorch;

        [SerializeField] private bool killsPrev;
        [Range(0.1f, 10f)]
        [SerializeField] private float timeToKill = 1.5f;
        #endregion

        /*protected override void Start()
        {
            base.Start();
            prevTorch = prev.GetComponent<Torch>();
            /*
            if (killsPrev)
            {
                StartCoroutine(KillPrevious());
            }
            
        }*/

        /* private void Update()
        {
            if (killsPrev)
            {
                StartCoroutine(KillPrevious());
            }
        }
        /// <summary>
        /// Light flame if a specific one is already lit
        /// </summary>
        protected override void Light()
        {
            if (prevTorch.isLit)
            {
                base.Light();
            }
        }

        IEnumerator KillPrevious()
        {
            if (prevTorch.isLit)
            {
                killsPrev = false;
                yield return new WaitForSeconds(timeToKill);
                if (!isLit)
                {
                    prevTorch.PutOut();
                }
                killsPrev = true;
            }

            //StartCoroutine(KillPrevious());
        }*/
    }

}
