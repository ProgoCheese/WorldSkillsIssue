using Leopotam.Ecs;
using UnityEngine;

namespace WorldSkillIssue
{
    public class BallThrowSystem : IEcsRunSystem
    {
        EcsFilter<InputDataComponent>.Exclude<ThrowTypeComponent> _filter;
        Configuration _configuration;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var inputData = ref _filter.Get1(i);

                if(inputData.endTime > 0.00001f)
                {
                    _filter.GetEntity(i).Get<ThrowTypeComponent>();
                }
                else
                {
                    Debug.Log("wfe");
                    _configuration.isThrow = false;
                }
            }
        }
    }
}