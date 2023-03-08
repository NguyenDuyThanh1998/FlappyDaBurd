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
        }

        #region Game States
        public void StartGame()
        {
            
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

        }
        #endregion

        #region Stuff that should have their own manager but I still suck at coding
        void ShowStartGameUI()
        {

        }

        //
        void FlashScreenOnDead()
        {

        }

        void ShowGameOverUI()
        {

        }

        //
        #endregion
    }
}
