using Assets.Code.Scripts.Models;
using Assets.Code.Scripts.Models.Gate;
using Assets.Code.Scripts.Views;
using System.Collections.Generic;

namespace Assets.Code.Scripts.Controllers
{
    internal class ScoreController
    {
        private readonly Score _score;
        private readonly ScoreView _scoreView;
        private readonly Dictionary<GateType, int> _scoreDictionary = new();

        public ScoreController(Score score, ScoreView scoreView)
        {
            _score = score;
            _scoreView = scoreView;

            _scoreDictionary.Add(GateType.First, 0);
            _scoreDictionary.Add(GateType.Second, 0);
        }

        public void Initialized()
        {
            _score.ScoreUpdate += ScoreUpdate;
        }

        public void Uninitialized()
        {
            _score.ScoreUpdate -= ScoreUpdate;
        }

        private void ScoreUpdate(int score, GateType gateType)
        {
            _scoreDictionary[gateType] = score;

            int scoreFirst = _scoreDictionary[GateType.Second];
            int scoreSecond = _scoreDictionary[GateType.First];

            _scoreView.SetScore(scoreFirst, scoreSecond);
        }
    }
}
