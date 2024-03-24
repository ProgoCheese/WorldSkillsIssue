using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldSkillIssue
{
    [CreateAssetMenu]
    public class SceneData : ScriptableObject
    {
        public GameCubeData[] LevelGameCube = new GameCubeData[4];

        public Transform spawnPosition;

        public Material[] material;
        public Material[] skinCube;

        public InputCubeType cubeType;

        public int[,] gameField;

        public int lenghtField;
        public int numberLevel;
        public int coinCounter;
        public int fieldFull;
        public int needFull;
        public int indexSkin;
        public int levelCountAll;

        public float speedCube;
        public float sizeCell;
        public float timerCube;

        public bool isWin;
        public bool isLose;
        public bool isGameOn;
        public bool isRandomLevel;
        public bool isStartGame;
    }
}
