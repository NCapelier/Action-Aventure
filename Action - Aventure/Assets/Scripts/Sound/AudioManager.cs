using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using Management;
using System;

namespace GameSound
{
    public enum MusicID { MainMenu, Caravan, Forest, Village, Dungeon, BossBattle, Null};
    /// <summary>
    /// CHB -- Based on Brackeys' AudioManager architecture
    /// </summary>
    public class AudioManager : Singleton<AudioManager>
	{
        #region Variables
        private Dictionary<string, AudioSource> d_sounds = new Dictionary<string, AudioSource>();
        [SerializeField] private Sound[] sounds;

        public Dictionary<string, Sound> sounds_notUniqueObject = new Dictionary<string, Sound>();

        public Dictionary<MusicID, AudioSource> musics = new Dictionary<MusicID, AudioSource>();
        [HideInInspector] public MusicID musicCurrentlyPlaying = MusicID.Null;
        #endregion
        private void Awake()
        {
            MakeSingleton(true);
            
            foreach(Sound s in sounds)
            {
                if (!s.notUniqueObject && !s.isMusic)
                {
                    MakeAudioSource(s, gameObject);

                    d_sounds.Add(s.clip.name, s.source);
                    s.zoneID = MusicID.Null;
                }
                else if (s.isMusic)
                {
                    MakeAudioSource(s, gameObject);
                    musics.Add(s.zoneID, s.source);
                }
                else if (s.notUniqueObject)
                {
                    sounds_notUniqueObject.Add(s.clip.name, s);
                }
            }
        }

        /// <summary>
        /// Set sounds in ready-to-play Audio Sources
        /// </summary>
        /// <param name="s"></param>
        public void MakeAudioSource(Sound s, GameObject go)
        {
            s.source = go.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            //s.source.playOnAwake = s.playAwake;
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

        public void PlayMusic(MusicID music)
        {
            if(musicCurrentlyPlaying != MusicID.Null)
            {
                musics[musicCurrentlyPlaying].Stop();
            }

            musics[music].Play();
            musicCurrentlyPlaying = music;
        }
    }
}

