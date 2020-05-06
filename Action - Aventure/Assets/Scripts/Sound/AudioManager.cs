using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using Management;
using System;

namespace GameSound
{
    /// <summary>
    /// CHB -- Based on Brackeys' AudioManager architecture
    /// </summary>
    public class AudioManager : Singleton<AudioManager>
	{
        #region Variables
        //Optimization possible by segmenting possible if getting a sound by string scanning is too slow with 40+ songs
        //Array[] soundFamilies;
        public Sound[] sounds;
        #endregion
        private void Awake()
        {
            //soundFamilies[0] = sounds;
            MakeSingleton(true);

            //foreach(Sound[] sFam in soundFamilies)
            foreach(Sound s in sounds) /*in sFam*/
            {
                GetSound(s);
            }
        }

        /// <summary>
        /// Set sounds in ready-to-play Audio Sources
        /// </summary>
        /// <param name="s"></param>
        void GetSound(Sound s)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        /// <summary>
        /// CHB -- Start playing a sound, called by name
        /// </summary>
        /// <param name="name"></param>
        public void Play(string name) /*Sound[] soundFamily*/
        {
            Sound s2p = Array.Find(sounds, sound => sound.name == name);

            if(s2p == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            s2p.source.Play();
        }
    }
}

