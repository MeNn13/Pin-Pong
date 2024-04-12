using Assets.Code.Scripts.Game;
using UnityEngine;

namespace Assets.Code.Scripts.Models
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _speed = 13f;
        public float Speed
        {
            get => _speed;
            private set
            {
                if (value >= 0)
                    _speed = value;
            }
        }

        public Vector2 Direction { get => _direction; }
        private Vector2 _direction = Vector2.zero;
        private MovementHandler _movementHandler = new();

        private void OnEnable()
        {
            GameManager.ChangeState += TryLunchBall;
        }

        private void OnDisable()
        {
            GameManager.ChangeState -= TryLunchBall;
        }

        private void Update()
        {
            _movementHandler.Move(transform, _direction, Speed, Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            DirectionInversion(collision.gameObject);
        }

        private void DirectionInversion(GameObject obj)
        {
            if (obj.CompareTag("Solid"))
                _direction.y = -_direction.y;
            else if (obj.CompareTag("Racket"))
                _direction.x = -_direction.x;
        }

        public void TryLunchBall(GameState state)
        {
            if (state == GameState.Playing)
                _direction = Vector2.one;
            else
                _direction = Vector2.zero;
        }
    }
}
