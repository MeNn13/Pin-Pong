using TMPro;
using UnityEngine;

namespace Assets.Code.Scripts.Views
{
    internal class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void SetScore(int scoreFirstPlayer, int scoreSecondPlayer)
        {
            _scoreText.text = $"{scoreFirstPlayer}:{scoreSecondPlayer}";
        }
    }
}