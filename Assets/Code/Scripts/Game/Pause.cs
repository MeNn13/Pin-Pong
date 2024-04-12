using System;
using UnityEngine;

namespace Assets.Code.Scripts.Game
{
    internal class Pause : IDisposable
    {
        public Pause()
        {
            GameManager.ChangeState += GameChangeState;
        }

        public void Dispose()
        {
            GameManager.ChangeState -= GameChangeState;
        }

        private void GameChangeState(GameState state) => Pausing(state);

        public void Pausing(GameState state)
        {
            if (state == GameState.Pausing || state == GameState.Stopping)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }
}
