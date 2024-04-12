using Zenject;

namespace Assets.Code.Scripts.Models.Installers
{
    internal class GameInstaller : MonoInstaller
    {
        private Score _score;

        public override void InstallBindings()
        {
            _score = new Score();

            Container.Bind<Score>().FromInstance(_score);
        }
    }
}
