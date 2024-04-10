using Assets.Code.Scripts;
using NUnit.Framework;

public class ScoreUnitTest
{
    private Score _score;
    private int _scoreStartValue;

    [SetUp]
    public void Setup()
    {
        _score = new Score();
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
