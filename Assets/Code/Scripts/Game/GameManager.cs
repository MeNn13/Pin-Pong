using System;
using UnityEngine;

namespace Assets.Code.Scripts.Game
{
    [RequireComponent(typeof(AudioSource))]
    public class GameManager : MonoBehaviour
    {
        public event Action<GameState> ChangeState;
        public event Action OnGameOver;

        [Header("Game Settings")]
        [SerializeField] private int _maxScoreForWin = 5;

        public static GameManager Instance { get; private set; }
        public GameState State { get; private set; }
        public readonly Score Score = new();

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

        private void OnEnable()
        {
            Score.ScoreUpdate += CheckGameScore;
        }

        private void OnDisable()
        {
            Score.ScoreUpdate -= CheckGameScore;
        }

        private void Start() => GamePause(true);

        private void Update()
        {
            if (State == GameState.Pausing && Input.anyKeyDown)
            {
                State = GameState.Playing;
                GamePause(false);
                ChangeState?.Invoke(State);
            }
        }

        private void OnApplicationFocus(bool focus) => GamePause(!focus);

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
                GameOver();
        }

        private void GameOver()
        {
            GamePause(true);
            OnGameOver?.Invoke();
        }
    }
}
