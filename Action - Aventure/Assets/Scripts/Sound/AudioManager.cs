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
        private Dictionary<string, AudioSource> d_sounds = new Dictionary<string, AudioSource>();
        [SerializeField] private Sound[] sounds;
        #endregion
        private void Awake()
        {
            MakeSingleton(true);
            
            foreach(Sound s in sounds)
            {
                MakeAudioSource(s);
            }
        }

        /// <summary>
        /// Set sounds in ready-to-play Audio Sources
        /// </summary>
        /// <param name="s"></param>
        void MakeAudioSource(Sound s)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            //s.source.playOnAwake = s.playAwake;

            d_sounds.Add(s.clip.name, s.source);
        }

        /// <summary>
        /// CHB -- Start playing a sound, called by name
        /// </summary>
        /// <param name="name"></param>
        public void Play(string name)
        {
            AudioSource s2p = GetSound(name);

            s2p.Play();
        }

        public AudioSource GetSound(string name)
        {
            AudioSource s2g = d_sounds[name];

            if (s2g == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return null;
            }

            return s2g;
        }
    }
}

