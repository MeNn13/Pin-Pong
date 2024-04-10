using UnityEngine;

namespace Assets.Code.Scripts.Game
{
    internal class Pause
    {
        public void Pausing(bool value)
        {
            if (value)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }
}
