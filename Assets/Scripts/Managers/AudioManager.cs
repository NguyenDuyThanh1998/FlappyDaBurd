using System.Collections.Generic;
using UnityEngine;

namespace Core.Audio
{
    /// <summary>
    /// Handles playing sounds and music based on their sound ID
    /// </summary>
    public class AudioManager : Singleton<AudioManager>
    {
        #region Class
        [System.Serializable]
        class SoundIDClipPair
        {
            public ESoundID m_SoundID;
            public AudioClip m_AudioClip;
        }
        #endregion

        #region Variables
        #region private
        [SerializeField]
        AudioSource m_MusicSource;
        [SerializeField]
        AudioSource m_EffectSource;
        [SerializeField, Min(0f)]
        float m_MinSoundInterval = 0.1f;
        [SerializeField]
        SoundIDClipPair[] m_Sounds;

        float m_LastSoundPlayTime;
        readonly Dictionary<ESoundID, AudioClip> m_Clips = new();

        AudioSettings m_AudioSettings = new();
        #endregion

        #region public
        /// <summary>
        /// (Un)mute the music
        /// </summary>
        public bool EnableMusic
        {
            get => m_AudioSettings.EnableMusic;
            set
            {
                m_AudioSettings.EnableMusic = value;
                m_MusicSource.mute = !value;
            }
        }

        /// <summary>
        /// (Un)mute all sound effects
        /// </summary>
        public bool EnableSfx
        {
            get => m_AudioSettings.EnableSfx;
            set
            {
                m_AudioSettings.EnableSfx = value;
                m_EffectSource.mute = !value;
            }
        }

        /// <summary>
        /// The Master volume of the audio listener
        /// </summary>
        public float MasterVolume
        {
            get => m_AudioSettings.MasterVolume;
            set
            {
                m_AudioSettings.MasterVolume = value;
                AudioListener.volume = value;
            }
        }
        #endregion
        #endregion

        #region Main
        void Start()
        {
            foreach (var sound in m_Sounds)
            {
                m_Clips.Add(sound.m_SoundID, sound.m_AudioClip);
            }
        }

        void OnEnable()
        {
            var audioSettings = GameManager.Instance.LoadAudioSettings();
            EnableMusic = audioSettings.EnableMusic;
            EnableSfx = audioSettings.EnableSfx;
            MasterVolume = audioSettings.MasterVolume;
        }

        void OnDisable()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SaveAudioSettings(m_AudioSettings);
                Debug.Log("Audio Settings Saved.");
            }
        }
        #endregion

        #region Methods
        void PlayMusic(AudioClip audioClip, bool looping = true)
        {
            if (m_MusicSource.isPlaying)
                return;

            m_MusicSource.clip = audioClip;
            m_MusicSource.loop = looping;
            m_MusicSource.Play();
        }

        /// <summary>
        /// Play a music based on its sound ID
        /// </summary>
        /// <param name="soundID">The ID of the music</param>
        /// <param name="looping">Is music looping?</param>
        public void PlayMusic(ESoundID soundID, bool looping = true)
        {
            PlayMusic(m_Clips[soundID], looping);
        }

        /// <summary>
        /// Stop the current music
        /// </summary>
        public void StopMusic()
        {
            m_MusicSource.Stop();
        }

        void PlayEffect(AudioClip audioClip)
        {
            if (Time.time - m_LastSoundPlayTime >= m_MinSoundInterval)
            {
                m_EffectSource.PlayOneShot(audioClip);
                m_LastSoundPlayTime = Time.time;
            }
        }

        /// <summary>
        /// Play a sound effect based on its sound ID
        /// </summary>
        /// <param name="soundID">The ID of the sound effect</param>
        public void PlayEffect(ESoundID soundID)
        {
            if (soundID == ESoundID.None)
                return;

            PlayEffect(m_Clips[soundID]);
        }
        #endregion
    }
}
