using Assets.Code.Scripts.Game;
using UnityEngine;

namespace Assets.Code.Scripts
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private string _ballTag;

        private Score _score => GameManager.Instance.Score;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(_ballTag))
                _score.ScoreUp();
        }
    }
}
