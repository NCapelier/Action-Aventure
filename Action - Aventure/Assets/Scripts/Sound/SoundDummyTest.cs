using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSound
{
	public class SoundDummyTest : MonoBehaviour
	{
        #region Variables
        bool isPlaying = false;
		#endregion


		// Update is called once per frame
		void Update()
		{
            if (Input.GetKeyDown(KeyCode.P) && !isPlaying)
            {
                isPlaying = true;
                StartCoroutine(SoundTest());
            }
		}

        IEnumerator SoundTest()
        {
            AudioManager.Instance.Play("Activate-deactivate");
            yield return new WaitForSeconds(3f);
            AudioManager.Instance.Play("Boss_growl");
            yield return new WaitForSeconds(3f);
            AudioManager.Instance.Play("Jibberish_Undertaker");
            yield return new WaitForSeconds(3f);

            isPlaying = false;
        }
	}
}

