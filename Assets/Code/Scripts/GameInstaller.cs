using Assets.Code.Scripts.Game;
using Zenject;

namespace Assets.Code.Scripts
{
    internal class GameInstaller : MonoInstaller
    {
        LocalDataBase _localDataBase;
        Score _score;

        public override void InstallBindings()
        {
            _localDataBase = new LocalDataBase();
            _score = new Score(_localDataBase);

            Container.Bind<LocalDataBase>().FromInstance(_localDataBase);
            Container.Bind<Score>().FromInstance(_score);
        }
    }
}
