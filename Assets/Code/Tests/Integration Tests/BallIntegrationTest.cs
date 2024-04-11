using Asset.Code.Script.Racket;
using Assets.Code.Scripts.Ball;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class BallIntegrationTest
{
    private Ball _ball;
    private MovementHandler _movementHandler;
    private Vector3 _startBallPosition;

    [SetUp]
    public void Setup()
    {
        _movementHandler = new MovementHandler();
        _ball = Resources.Load<Ball>("Ball");
        Object.Instantiate(_ball);
        _startBallPosition = _ball.transform.position;
    }

    [TearDown]
    public void TearDown()
    {
        _movementHandler = null;
        _ball = null;
        _startBallPosition = Vector3.zero;
    }

    [UnityTest]
    public IEnumerator LunchBallInRandomDirection()
    {
        yield return new WaitForSeconds(.1f);

        _movementHandler.Move(_ball.transform, Vector2.one, _ball.Speed, Time.deltaTime);

        yield return new WaitForSeconds(.1f);

        Assert.AreNotEqual(_startBallPosition, _ball.transform.position);
    }
}
