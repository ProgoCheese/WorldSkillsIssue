using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace WorldSkillIssue
{
    public class Loader : MonoBehaviour
    {
        public static string savePath { get; private set; }
        public SceneData _sceneData;
        private int[,] field;

        // Start is called before the first frame update
        void Awake()
        {
            savePath = Application.dataPath;
            
            for (int i = 1; i <= _sceneData.LevelGameCube.Length; i++)
            {
                CubeDataJsonRider cudeData = JsonConvert.DeserializeObject<CubeDataJsonRider>(File.ReadAllText(savePath + "/Resources/Cube/Level" + i + ".json"));

                GameCubeData gameData = new GameCubeData();
                gameData.gameField = ConvertOneToTwoArray(cudeData.gameField, cudeData.length);
                gameData.numberLevel = i;
                gameData.lenghtField = cudeData.length;
                gameData.needFull = cudeData.needCellToWin;
               // Debug.Log(_sceneData.LevelGameCube);
                _sceneData.LevelGameCube[i-1] = gameData;
            }
        }

        public void SetGameStartCubeMenu()
        {
            _sceneData.cubeType = InputCubeType.None;
            _sceneData.numberLevel = 1;
            _sceneData.isGameOn = true;
            _sceneData.isLose = false;
            _sceneData.isRandomLevel = false;
            _sceneData.isStartGame = false;
            SceneManager.LoadScene(2);
        }

        private int[,] ConvertOneToTwoArray(int[] array, int length)
        {
            int[,] gameField = new int[length, length];

            int i = 0;
            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    gameField[x, y] = array[i];
                    i++;
                }
            }

            return gameField;
        }
    }
    [Serializable]
    public class CubeDataJsonRider
    {
        public string nameLevel;
        public int[] gameField;
        public int length;
        public int needCellToWin;
    }

    public class GameCubeData
    {
        public int[,] gameField;

        public int lenghtField;
        public int numberLevel;
        public int needFull;
    }
}
