using System;
using UnityEngine;

namespace Assets.Code.Scripts.Game
{
    public class LocalDataBase
    {
        public GameInfo GameInfo;
        private readonly string _key = "Game";

        public LocalDataBase() => QuickLoad();

        public void QuickLoad()
        {
            GameInfo gameInfo = JsonUtility.FromJson<GameInfo>(PlayerPrefs.GetString(_key));

            if (gameInfo != null)
                GameInfo = gameInfo;
            else
            {
                GameInfo = new GameInfo();
                QuickSave();
            }
        }

        public void QuickSave()
        {
            string json = JsonUtility.ToJson(_key);
            PlayerPrefs.SetString("Game", json);
        }
    }

    [Serializable]
    public class GameInfo
    {
        public int Score = 0;
    }
}
