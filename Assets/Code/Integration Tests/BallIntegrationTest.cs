using Assets.Code.Scripts.Ball;
using NUnit.Framework;
using System.Collections;
using UnityEngine;

[TestFixture]
public class BallIntegrationTest
{
    private Ball _ball;
    private Vector3 _startBallPosition;

    [SetUp]
    public void Setup()
    {
        _ball = Resources.Load<Ball>("Ball");
        Object.Instantiate(_ball);
        _startBallPosition = _ball.transform.position;
    }

    [TearDown]
    public void TearDown()
    {
        _ball = null;
        _startBallPosition = Vector3.zero;
    }

    public IEnumerator LunchBallInRandomDirection()
    {
        yield return new WaitForSeconds(.1f);

        _ball.LunchBallInRandomDirection();

        yield return new WaitForSeconds(.1f);

        Assert.AreNotEqual(_startBallPosition, _ball.transform.position);
    }
}
