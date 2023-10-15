using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlappyDaBurd;

namespace Core
{
    public class GameManager : Singleton<GameManager>
    {
        private void Awake()
        {
            ShowStartGameUI();
            LoadAudioSettings();
        }

        #region Game States
        public void StartGame()
        {
            //Flappy.Instance.SetPhysics(true);
        }

        public void GameOver()
        {
            FlashScreenOnDead();
            Flappy.Instance.PlayDeadAnimation();
            ShowGameOverUI();
        }

        public void Restart()
        {
            if (Flappy.Instance != null)
            {
                Flappy.Instance.SetDefaultValues();
            }
            if (Map.Instance != null)
            {
                Map.Instance.ResetSpawnables();
            }
        }

        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Resume()
        {
            Time.timeScale = 1;
        }
        #endregion

        #region Stuff that should have their own manager but I still suck at coding
        void ShowStartGameUI()
        {

        }

        void FlashScreenOnDead()
        {

        }

        void ShowGameOverUI()
        {

        }

        public Audio.AudioSettings LoadAudioSettings()
        {
            return null;
        }

        public Audio.AudioSettings SaveAudioSettings(Audio.AudioSettings _audio)
        {
            return null;
        }
        #endregion
    }
}
