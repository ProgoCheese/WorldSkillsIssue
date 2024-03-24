using Leopotam.Ecs;
using UnityEngine;

namespace WorldSkillIssue
{
    public class MovementSystem : IEcsRunSystem
    {
        private EcsFilter<ThrowTypeComponent, MovementComponent, InputDataComponent>.Exclude<FlyComponent> _filter;
        private Configuration _configuration;

        public void Run()
        {
            if (_configuration.isThrow)
            {
                foreach (var i in _filter)
                {
                    var ballMove = _filter.Get2(i);
                    var inputData = _filter.Get3(i);

                    Vector3 startPos = Camera.main.ScreenToWorldPoint(new Vector3(inputData.startPosition.x, inputData.startPosition.y, 0f));
                    Vector3 endPos = Camera.main.ScreenToWorldPoint(new Vector3(inputData.endPosition.x, inputData.endPosition.y, _configuration.deltaZ));

                    _filter.GetEntity(i).Get<FlyComponent>();

                    Vector3 throwDirection = (endPos - startPos).normalized;

                    if ((inputData.endTime - inputData.startTime) < 0.3f && _configuration.isThrow)
                    {

                        ballMove.rb.AddForce(throwDirection * _configuration.forseThrow * (0.3f - (inputData.endTime - inputData.startTime)), ForceMode.Impulse);

                        ballMove.rb.useGravity = true;

                        //Debug.Log("hvguhoi");
                    }

                    inputData.endTime = 0f;
                    inputData.startTime = 0f;

                    _configuration.isThrow = false;

                    _filter.GetEntity(i).Del<ThrowTypeComponent>();
                }
            }

        }
    }
}