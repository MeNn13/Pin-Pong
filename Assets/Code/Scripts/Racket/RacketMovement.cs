using UnityEngine;

namespace Asset.Code.Script.Racket
{
    public class RacketMovement
    {
        public void Move(Transform transform, float inputY, float speed, float deltaTime)
        {
            Vector3 direction = new Vector3(0, inputY, 0);
            transform.position += direction * speed * deltaTime;
        }
    }
}