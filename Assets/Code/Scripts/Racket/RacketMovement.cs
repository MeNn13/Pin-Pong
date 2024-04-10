using UnityEngine;

namespace Asset.Code.Script.Racket
{
    internal class RacketMovement
    {
        private Vector2 _direction;

        public void Move(Transform transform, float speed)
        {
            _direction = InputDirection();
            transform.position = _direction * speed * Time.deltaTime;
        }

        private Vector2 InputDirection()
        {
            float moveY = Input.GetAxis("Vertical");
            return new Vector2(0, moveY);
        }
    }
}