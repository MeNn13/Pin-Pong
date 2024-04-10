using System;
using UnityEngine;

namespace Assets.Code.Scripts.Game
{
    public class LocalDataBase
    {
        private GameInfo _gameInfo;
        private string _key = "Game";

        public LocalDataBase() => QuickLoad();

        public void QuickLoad()
        {
            GameInfo gameInfoData = JsonUtility.FromJson<GameInfo>(PlayerPrefs.GetString(_key));

            if (gameInfoData == null)
                _gameInfo = new GameInfo();
            else
                _gameInfo = gameInfoData;
        }

        public void QuickSave()
        {
            string json = JsonUtility.ToJson(_gameInfo);
            PlayerPrefs.SetString(_key, json);
        }
    }

    [Serializable]
    public class GameInfo
    {
        public int Score = 0;
    }
}
