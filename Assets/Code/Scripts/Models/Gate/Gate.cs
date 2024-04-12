using UnityEngine;
using Zenject;

namespace Assets.Code.Scripts.Models.Gate
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private string _ballTag;
        [SerializeField] private GateType _gateType;

        [Inject]
        private readonly Score _score;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(_ballTag))
                _score.ScoreUp(_gateType);
        }
    }
}
