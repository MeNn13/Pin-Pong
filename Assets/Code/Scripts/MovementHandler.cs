using UnityEngine;

namespace Asset.Code.Script.Racket
{
    public class MovementHandler
    {
        public void Move(Transform transform, Vector3 direction, float speed, float deltaTime)
        {
            transform.Translate(direction * speed * deltaTime);
        }
    }
}