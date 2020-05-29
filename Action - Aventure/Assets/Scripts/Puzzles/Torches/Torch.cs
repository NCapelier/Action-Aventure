using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    /// <summary>
    /// CHB -- Torch to be lit when Will of the wisp passes upon
    /// </summary>
    public class Torch : MonoBehaviour
    {
        #region Variables
        public bool isLit;
        private GameObject flameObject;
        private ParticleSystem flame;
        #endregion

        public float Duration;
    

        // Start is called before the first frame update
        void Start()
        {
            flameObject = gameObject.GetChildNamed("Flame");
            flame = flameObject.GetComponent<ParticleSystem>();
            flame.gameObject.SetActive(false); 
            isLit = false;
   
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Hinky" )
            {
                isLit = true;


            }
            else { isLit = false; }

          
        }
        /// <summary>
        /// Lights flame. To be called when the right object collides.
        /// </summary>
        private void Light()
        {
            
            flame.gameObject.SetActive(true);
            isLit = true;

        }
        private void Update()
        {
            if(isLit == true)
            {
                Light();
            }
            TTK();
            
        }
       
         IEnumerator TTK()
        {
            if (isLit == true)
            {
                yield return new WaitForSeconds(Duration);
                isLit = false;
                flame.gameObject.SetActive(false);
            }
        }

    }

}
