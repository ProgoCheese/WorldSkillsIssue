using UnityEngine;

namespace WorldSkillIssue
{
    public struct InputDataComponent
    {
        public Collider collider;
        public Transform transform;

        public Vector3 startPosition;
        public Vector3 endPosition;

        public float startTime;
        public float endTime;
        public float Durtion => endTime - startTime;
    }
}