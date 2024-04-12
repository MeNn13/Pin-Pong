using UnityEngine;

namespace Assets.Code.Scripts.Models
{
    public class Racket : MonoBehaviour
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

        private MovementHandler _racketMovement = new();

        private void FixedUpdate()
        {
            _racketMovement.Move(transform, new Vector2(0, Input.GetAxis("Vertical")), _speed, Time.fixedDeltaTime);
        }
    }
}
