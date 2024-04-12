using Assets.Code.Scripts.Game;
using Assets.Code.Scripts.Models;
using Assets.Code.Scripts.Models.Gate;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Code.Tests.Unit_Tests
{
    [TestFixture]
    public class ScoreUnitTest
    {
        private Score _score;
        GateType firstGate = GateType.First;
        GateType secondGate = GateType.Second;
        private int _scoreStartValueFirstPlayer;
        private int _scoreStartValueSecondPlayer;

        [SetUp]
        public void Setup()
        {
            _score = new Score();
            _scoreStartValueFirstPlayer = _score.ScoreDictionary[firstGate];
            _scoreStartValueSecondPlayer = _score.ScoreDictionary[secondGate];
        }

        [TearDown]
        public void TearDown()
        {
            _score = null;
            _scoreStartValueFirstPlayer = 0;
            _scoreStartValueSecondPlayer = 0;
        }

        [Test]
        public void WhenBallToFirstGate_ScoreUp()
        {
            _score.ScoreUp(firstGate);

            Debug.Log(firstGate);
            Assert.Greater(_score.ScoreDictionary[firstGate], _scoreStartValueFirstPlayer);
        }

        [Test]
        public void WhenBallToSecondGate_ScoreUp()
        {
            _score.ScoreUp(secondGate);

            Debug.Log(secondGate);
            Assert.Greater(_score.ScoreDictionary[secondGate], _scoreStartValueSecondPlayer);
        }
    }
}
