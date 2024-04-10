using UnityEngine;

namespace Assets.Code.Scripts.Game
{
    [RequireComponent(typeof(AudioSource))]
    internal class Audio
    {
        private AudioSource _audioSource;

        public Audio(AudioSource audioSource) => _audioSource = audioSource;

        public void Silence(bool value)
        {
            if (value)
                _audioSource.Pause();
            else
                _audioSource.Play();
        }
    }
}
