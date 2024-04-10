using UnityEngine;

namespace Assets.Code.Scripts.Game
{
    [RequireComponent(typeof(AudioSource))]
    public class Game : MonoBehaviour
    {
        public static Game Instance { get; private set; }

        public GameState State { get; private set; }

        private Pause _pause = new();
        private Audio _audio;
        private AudioSource _audioSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }

            _audioSource = GetComponent<AudioSource>();
            _audio = new(_audioSource);
        }

        private void OnApplicationFocus(bool focus) => GamePause(!focus);

        private void GamePause(bool value)
        {
            if (value)
            {
                State = GameState.Pausing;
                _pause.Pausing(value);
                _audio.Silence(value);
            }
            else
            {
                State = GameState.Playing;
                _pause.Pausing(value);
                _audio.Silence(value);
            }
        }
    }
}
