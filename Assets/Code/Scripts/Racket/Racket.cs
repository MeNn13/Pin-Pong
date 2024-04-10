using Asset.Code.Script.Racket;
using UnityEngine;

namespace Assets.Code.Scripts.Racket
{
    public class Racket : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;
        public float Speed
        {
            get => _speed;
            private set
            {
                if (value >= 0)
                    _speed = value;
            }
        }

        private RacketMovement _racketMovement;

        private void Awake()
        {
            _racketMovement = new RacketMovement();
        }

        private void Update()
        {
            _racketMovement.Move(transform, Input.GetAxis("Vertical"), _speed, Time.deltaTime);
        }       
    }
}
