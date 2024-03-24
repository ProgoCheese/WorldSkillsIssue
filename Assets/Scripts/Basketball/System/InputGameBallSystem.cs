using Leopotam.Ecs;
using UnityEngine;

namespace WorldSkillIssue
{
    public class InputGameBallSystem : IEcsRunSystem
    {
        private EcsFilter<InputDataComponent> _filter;
        private Configuration _configuration;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var inputData = ref _filter.Get1(i);

                if(Input.GetMouseButtonDown(0))
                {
                    inputData.startTime = Time.time;
                    inputData.startPosition = Input.mousePosition;
                    //Debug.Log(inputData.startTime);
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    inputData.endTime = Time.time;
                    inputData.endPosition = Input.mousePosition;
                    inputData.endPosition.z = _configuration.deltaZ;
                    ref var entity = ref _filter.GetEntity(i);

                    //Debug.Log(inputData.startTime + " <-  " + (inputData.endTime - inputData.startTime));

                    _configuration.isThrow = true;
                }
            }
        }
    }
}