using System;
using UnityEngine;

namespace Assets.Code.Scripts.Game
{
    internal class Audio : IDisposable
    {
        private AudioSource _audioSource;

        public Audio(AudioSource audioSource)
        {
            _audioSource = audioSource;
            GameManager.ChangeState += GameChangeState;
        }

        public void Dispose()
        {
            GameManager.ChangeState -= GameChangeState;
        }

        private void GameChangeState(GameState state) => Silence(state);

        public void Silence(GameState state)
        {
            if (state == GameState.Pausing || state == GameState.Stopping)
                _audioSource.Pause();
            else
                _audioSource.Play();
        }
    }
}
