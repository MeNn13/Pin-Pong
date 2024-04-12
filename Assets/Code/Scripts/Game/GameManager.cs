using System;
using UnityEngine;
using Zenject;

namespace Assets.Code.Scripts.Game
{
    [RequireComponent(typeof(AudioSource))]
    public class GameManager : MonoBehaviour
    {
        public static event Action<GameState> ChangeState;
        public static event Action OnGameOver;

        [Header("Game Settings")]
        [SerializeField] private int _maxScoreForWin = 5;
        [SerializeField] private Spawner _spawner;

        private GameState State
        {
            get => _state; set
            {
                _state = value;
                ChangeState.Invoke(_state);
            }
        }

        [Inject]
        private readonly Score Score;

        private Pause _pause = new();
        private Audio _audio;
        private AudioSource _audioSource;
        private GameState _state;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audio = new(_audioSource);
            _spawner.Spawn();
            State = GameState.Stopping;
        }

        private void OnEnable()
        {
            Score.ScoreUpdate += CheckGameScore;
        }

        private void OnDisable()
        {
            Score.ScoreUpdate -= CheckGameScore;
        }

        private void Update() => TryStartGame();

        private void TryStartGame()
        {
            if (State == GameState.Stopping && Input.GetKeyDown(KeyCode.Space))
            {
                State = GameState.Playing;
                GamePause(false);
            }
        }

        private void OnApplicationFocus(bool focus)
        {
            if (State != GameState.Stopping)
                GamePause(!focus);
        }

        private void GamePause(bool value)
        {
            if (value)
                State = GameState.Pausing;
            else
                State = GameState.Playing;

            _pause.Pausing(State);
            _audio.Silence(State);
        }

        private void CheckGameScore(int score)
        {
            if (score == _maxScoreForWin)
                OnGameOver?.Invoke();

            State = GameState.Stopping;
            _spawner.Spawn();
        }
    }
}
