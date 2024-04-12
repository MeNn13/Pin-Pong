using UnityEngine;

namespace Assets.Code.Scripts.Models
{
    public class MovementHandler
    {
        public void Move(Transform transform, Vector3 direction, float speed, float deltaTime)
        {
            transform.Translate(direction * speed * deltaTime);
        }
    }
}