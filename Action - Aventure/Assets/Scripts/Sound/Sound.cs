﻿using UnityEngine.Audio;
using UnityEngine;

namespace GameSound
{
    /// <summary>
    /// CHB -- Based on Brackeys' AudioManager architecture
    /// </summary>
    [System.Serializable]
    public class Sound
	{
        #region Variables
        public string name;
        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume = 0.9f;
        [Range(0.1f, 3f)]
        public float pitch = 1f;

        public bool loop;

        [HideInInspector]
        public AudioSource source;
        #endregion
	}
}
