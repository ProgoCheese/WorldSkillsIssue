using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace WorldSkillIssue
{
    public class SceneLoader : MonoBehaviour
    {
        public SceneData _sceneData;
        public Text coinText;

        public void LoadScene(int id)
        {
            SceneManager.LoadScene(id);
        }

        public void GetCoin(int addCoin)
        {
            _sceneData.coinCounter += addCoin;
        }

        private void Update()
        {
            if (coinText != null)
            {
                coinText.text = "Монет: " + _sceneData.coinCounter;
            }
        }

        public void OnStartGameCubeMenu()
        {
            _sceneData.cubeType = InputCubeType.None;
            _sceneData.numberLevel = 1;
            _sceneData.isGameOn = false;
            _sceneData.fieldFull = 0;
            _sceneData.isLose = false;
            _sceneData.isRandomLevel = false;
            _sceneData.isStartGame = true;
            SceneManager.LoadScene(2);
        }
    }
}
