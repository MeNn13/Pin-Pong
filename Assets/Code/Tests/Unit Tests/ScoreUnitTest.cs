using Assets.Code.Scripts;
using Assets.Code.Scripts.Game;
using NUnit.Framework;

namespace Assets.Code.Tests.Unit_Tests
{
    public class ScoreUnitTest
    {
        private Score _score;
        private LocalDataBase _localDataBase;
        private int _scoreStartValue;

        [SetUp]
        public void Setup()
        {
            _localDataBase = new LocalDataBase();
            _score = new Score(_localDataBase);
            _scoreStartValue = _score.ScoreProperty;
        }

        [TearDown]
        public void TearDown()
        {
            _score = null;
            _scoreStartValue = 0;
        }

        [Test]
        public void WhenBallToGate_ScoreUp()
        {
            _score.ScoreUp();

            Assert.Greater(_score.ScoreProperty, _scoreStartValue);
        }
    }
}
