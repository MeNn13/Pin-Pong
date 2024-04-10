using UnityEngine;

namespace Assets.Code.Scripts.Game
{
    internal class Pause
    {
        public void Pausing(GameState state)
        {
            if (state == GameState.Pausing)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }
}
