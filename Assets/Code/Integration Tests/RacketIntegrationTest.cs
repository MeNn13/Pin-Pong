using Asset.Code.Script.Racket;
using Assets.Code.Scripts.Racket;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class RacketIntegrationTest
{
    private Racket _racket;
    private RacketMovement _movement;
    private float _racketStartAxisY;

    [SetUp]
    public void Setup()
    {
        _racket = Resources.Load<Racket>("Racket");
        Object.Instantiate(_racket);
        _racketStartAxisY = _racket.transform.position.y;
        _movement = new RacketMovement();
    }

    [TearDown]
    public void TearDown()
    {
        _racket = null;
        _racketStartAxisY = 0f;
        _movement = null;
    }

    [UnityTest]
    public IEnumerator RacketMovementUp()
    {
        float axisY = 1;

        yield return new WaitForSeconds(.1f);

        _movement.Move(_racket.transform, axisY, _racket.Speed, Time.deltaTime);

        yield return new WaitForSeconds(.1f);

        Assert.Greater(_racket.transform.position.y, _racketStartAxisY);
    }

    [UnityTest]
    public IEnumerator RacketMovementDown()
    {
        float axisY = -1;

        yield return new WaitForSeconds(.1f);

        _movement.Move(_racket.transform, axisY, _racket.Speed, Time.deltaTime);

        yield return new WaitForSeconds(.1f);

        Assert.Less(_racket.transform.position.y, _racketStartAxisY);
    }

    [UnityTest]
    public IEnumerator RacketMovementIsStop()
    {
        float axisY = 0;

        yield return new WaitForSeconds(.1f);

        _movement.Move(_racket.transform, axisY, _racket.Speed, Time.deltaTime);

        yield return new WaitForSeconds(.1f);

        Assert.AreEqual(_racket.transform.position.y, _racketStartAxisY);
    }
}
