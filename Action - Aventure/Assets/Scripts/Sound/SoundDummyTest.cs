using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSound
{
	public class SoundDummyTest : MonoBehaviour
	{
        #region Variables
        bool isPlaying = false;

        AudioSource music;
        bool musicOn = false;

        [SerializeField] MusicID choosenZik;
        #endregion

        private void Start()
        {
            music = AudioManager.Instance.musics[choosenZik];
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

            if (Input.GetKeyDown(KeyCode.K))
            {
                SceneManager.LoadScene("CHB_ZikDestination");
            }
		}

        IEnumerator SoundTest()
        {
            AudioManager.Instance.Play("Player_fall");
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
                    AudioManager.Instance.musicCurrentlyPlaying = choosenZik;
                    musicOn = true;
                    break;

                case true:
                    music.Stop();
                    AudioManager.Instance.musicCurrentlyPlaying = MusicID.Null;
                    musicOn = false;
                    break;
            }
        }
	}
}

