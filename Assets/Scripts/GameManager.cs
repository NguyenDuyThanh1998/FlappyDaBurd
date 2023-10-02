using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyDaBurd.Core
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

        public AudioSettings LoadAudioSettings()
        {
            return null;
        }

        public AudioSettings SaveAudioSettings(AudioSettings audio)
        {
            return null;
        }
        #endregion
    }
}
