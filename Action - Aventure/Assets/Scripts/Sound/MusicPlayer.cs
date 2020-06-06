using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSound
{
    /// <summary>
    /// CHB -- Switches to requested music when loading new scene
    /// </summary>
	public class MusicPlayer : MonoBehaviour
	{
        #region Variables
        [SerializeField] MusicID zoneID;
		#endregion

		// Start is called before the first frame update
		void Start()
		{
			if (zoneID != AudioManager.Instance.musicCurrentlyPlaying)
            {
                AudioManager.Instance.musics[AudioManager.Instance.musicCurrentlyPlaying].Stop();

                AudioManager.Instance.musics[zoneID].Play();
                AudioManager.Instance.musicCurrentlyPlaying = zoneID;
            }
		}

		// Update is called once per frame
		void Update()
		{
			
		}
	}
}

