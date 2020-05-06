using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using Management;
using System;

namespace GameSound
{
    public class AudioManager : Singleton<AudioManager>
	{
        #region Variables
        public Sound[] sounds;
        #endregion
        private void Awake()
        {
            MakeSingleton(true);

            foreach(Sound s in sounds)
            {
                GetSound(s);
            }
        }

        void GetSound(Sound s)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        public void Play(string name)
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

