using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    /// <summary>
    /// CHB -- Open a blockade when all desired torches lit.
    /// </summary>
	public class TorchBlockade : MonoBehaviour
	{
        #region Variables
        [SerializeField] private GameObject torchMaster;
        private TorchTTK[] torches;

        [SerializeField] private GameObject door;
		#endregion

		// Start is called before the first frame update
		void Start()
		{
            torches = torchMaster.GetComponentsInChildren<TorchTTK>();
            //Debug.Log(torches.Length + " à allumer");
		}

		// Update is called once per frame
		void Update()
		{
			for(int l = 0; l < torches.Length;)
            {
                if (torches[l].isLit)
                {
                    //Increment lit torches count.
                    l++;
                }
                else
                {
                    //Start over if any false encountered.
                    break;
                }

                if(l == torches.Length)
                {
                    //Means all desired torches are lit, so...
                    OpenDoor();
                }

                Debug.Log(l + " allumées !");
            }
		}

        /// <summary>
        /// Call to open the blockade.
        /// </summary>
        void OpenDoor()
        {
            door.SetActive(false);
        }
	}
}

