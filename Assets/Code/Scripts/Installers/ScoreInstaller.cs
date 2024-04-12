using Assets.Code.Scripts.Controllers;
using Assets.Code.Scripts.Models;
using Assets.Code.Scripts.Models.Gate;
using Assets.Code.Scripts.Views;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Code.Scripts.Installers
{
    internal class ScoreInstaller : MonoBehaviour
    {
        [SerializeField] private ScoreView _scoreView;

        [Inject]
        private Score _score;

        private ScoreController _scoreController;

        public void Awake()
        {
            ScoreView view = Instantiate(_scoreView, transform);
            _scoreController = new(_score, view);
        }

        private void OnEnable() => _scoreController.Initialized();

        private void OnDisable() => _scoreController.Uninitialized();
    }
}
