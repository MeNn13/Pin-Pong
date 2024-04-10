using Assets.Code.Scripts.Game;
using UnityEngine;

namespace Assets.Code.Scripts.Ball
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        private Vector2 _direction = Vector2.zero;
        private Rigidbody2D _rb;

        private GameState GameState => GameManager.Instance.State;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if(GameState == GameState.Playing)
                LunchBallInRandomDirection();
        }

        public void LunchBallInRandomDirection() => _rb.AddForce(GetRandomDirection());

        private Vector2 GetRandomDirection()
        {
            float x = Random.Range(1, -1);
            float y = Random.Range(1, -1);

            return new Vector2(x, y);
        }
    }
}
