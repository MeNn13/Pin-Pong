using Assets.Code.Scripts.Game;
using System;
using Zenject;

namespace Assets.Code.Scripts
{
    public class Score
    {
        public event Action<int> ScoreUpdate;

        private int _score;
        public int ScoreProperty
        {
            get => _score;
            private set
            {
                if (value >= 0)
                    _score = value;
            }
        }

        private readonly LocalDataBase _localDataBase;

        public Score(LocalDataBase localDataBase)
        {
            _localDataBase = localDataBase;
        }

        public void ScoreUp()
        {
            ScoreProperty++;
            _localDataBase.GameInfo.Score = ScoreProperty;
            ScoreUpdate?.Invoke(ScoreProperty);
        }
    }
}
