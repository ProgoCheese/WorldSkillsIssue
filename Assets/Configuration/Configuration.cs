using UnityEngine;

namespace WorldSkillIssue
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject
    {
        public GameBasketData basketballData;
        public GameObject ball;
        public Camera camera;
        public Transform[] spawnBall;
        public Transform[] transformCamera;

        public float deltaZ;
        public float forseThrow;

        public bool isThrow;
        public bool isBonusThrow;

        public int goalCounter;
        public int targetGoal;
        public int recordingGoal;
        public int levelBall;
    }
}