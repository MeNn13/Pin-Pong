using Assets.Code.Scripts.Models.Gate;
using System;
using System.Collections.Generic;

namespace Assets.Code.Scripts.Models
{
    public class Score
    {
        public event Action<int, GateType> ScoreUpdate;

        public Dictionary<GateType, int> ScoreDictionary { get => _scoreDictionary; }
        private Dictionary<GateType, int> _scoreDictionary = new();

        public Score()
        {
            _scoreDictionary.Add(GateType.First, 0);
            _scoreDictionary.Add(GateType.Second, 0);
        }

        public void ScoreUp(GateType gateType)
        {
            _scoreDictionary[gateType]++;

            ScoreUpdate?.Invoke(_scoreDictionary[gateType], gateType);
        }
    }
}
