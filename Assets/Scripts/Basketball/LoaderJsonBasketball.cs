using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace WorldSkillIssue
{
    public class LoaderJsonBasketball : MonoBehaviour
    {
        public static string savePath { get; private set; }
        public Configuration _configuration;
        private int[,] field;

        void Awake()
        {
            savePath = Application.dataPath;

                GameBasketJsonData cudeData = JsonConvert.DeserializeObject<GameBasketJsonData>(File.ReadAllText(savePath + "/Resources/Basketball/Level.json"));

                GameBasketData gameData = new GameBasketData();
                gameData.targetGoal = cudeData.targetGoal;
                gameData.stateThrowBall= cudeData.stateThrowBall;
                // Debug.Log(_sceneData.LevelGameCube);
                _configuration.basketballData = gameData;
        }
    }
    [Serializable]
    public class GameBasketJsonData
    {
        public int[] stateThrowBall;
        public int[] targetGoal;
    }

    public class GameBasketData
    {
        public int[] stateThrowBall;
        public int[] targetGoal;
    }
}
