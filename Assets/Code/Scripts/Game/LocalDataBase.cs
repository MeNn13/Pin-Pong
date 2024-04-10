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
            GameInfo gameInfoData = JsonUtility.FromJson<GameInfo>(PlayerPrefs.GetString(_key));

            if (gameInfoData == null)
                GameInfo = new GameInfo();
            else
                GameInfo = gameInfoData;
        }

        public void QuickSave()
        {
            string json = JsonUtility.ToJson(GameInfo);
            PlayerPrefs.SetString(_key, json);
        }
    }

    [Serializable]
    public class GameInfo
    {
        public int Score = 0;
    }
}
