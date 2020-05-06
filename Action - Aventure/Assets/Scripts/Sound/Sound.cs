using UnityEngine.Audio;
using UnityEngine;

namespace GameSound
{
    [System.Serializable]
    public class Sound : MonoBehaviour
	{
        #region Variables
        public new string name;
        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;
        [Range(0.1f, 3f)]
        public float pitch;

        public bool loop;

        [HideInInspector]
        public AudioSource source;
        #endregion
	}
}

