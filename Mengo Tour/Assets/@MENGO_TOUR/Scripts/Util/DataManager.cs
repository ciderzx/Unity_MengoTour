using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    [Serializable]
    public struct InGameData
    {
        public string countryNm;
        public int timer;
    }

    public class DataManager : Singleton<DataManager>
    {
        [SerializeField] private InGameData gameData;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        public void SetGameData(InGameData data)
        {
            gameData = data;
        }

        public InGameData GetGameData()
        {
            return gameData;
        }
    }
}

