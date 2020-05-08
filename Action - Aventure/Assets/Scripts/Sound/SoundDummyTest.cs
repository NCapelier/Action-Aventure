using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSound
{
	public class SoundDummyTest : MonoBehaviour
	{
        #region Variables
        bool isPlaying = false;

        AudioSource music;
        bool musicOn = false;
        #endregion

        private void Start()
        {
            music = AudioManager.Instance.GetSound("[Village-House] Nostalgia- Sungha Jung_g");
        }

        // Update is called once per frame
        void Update()
		{
            if (Input.GetKeyDown(KeyCode.P) && !isPlaying)
            {
                isPlaying = true;
                StartCoroutine(SoundTest());
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                ToggleMusic();
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

        void ToggleMusic()
        {
            switch (musicOn)
            {
                case false:
                    music.Play();
                    musicOn = true;
                    break;

                case true:
                    music.Stop();
                    musicOn = false;
                    break;
            }
        }
	}
}

