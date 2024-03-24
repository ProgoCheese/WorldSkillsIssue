using Leopotam.Ecs;
using UnityEngine;

namespace WorldSkillIssue
{
    public class GameInitSystem : IEcsInitSystem
    {
        Configuration _configuration;
        EcsWorld _world;

        public void Init()
        {
            _configuration.levelBall = 0;

            GameObject ballGameObject = GameObject.Instantiate(_configuration.ball);
            Rigidbody rb = ballGameObject.GetComponent<Rigidbody>();
            Collider collider = ballGameObject.GetComponent<Collider>();
            Transform transform = ballGameObject.GetComponent<Transform>();

            rb.useGravity = false;

            Debug.Log(_configuration.basketballData.stateThrowBall[0]);

            if (_configuration.basketballData.stateThrowBall[_configuration.levelBall] == 1)
            {
                ballGameObject.transform.position = _configuration.spawnBall[0].position;
            }
            else if (_configuration.basketballData.stateThrowBall[_configuration.levelBall] == 2)
            {
                ballGameObject.transform.position = _configuration.spawnBall[1].position;
            }
            else if (_configuration.basketballData.stateThrowBall[_configuration.levelBall] == 3)
            {
                ballGameObject.transform.position = _configuration.spawnBall[2].position;
            }

            var ball = _world.NewEntity();
            ref var inputDataComponent = ref ball.Get<InputDataComponent>();
            ref var MoveDataComponent = ref ball.Get<MovementComponent>();
            MoveDataComponent.rb = rb;
            MoveDataComponent.rb.useGravity = false;
            inputDataComponent.collider = collider;
            inputDataComponent.transform = transform;

            if (_configuration.basketballData.stateThrowBall[_configuration.levelBall] == 1)
            {
                _configuration.camera.transform.position = _configuration.transformCamera[0].position;
                _configuration.camera.transform.rotation = _configuration.transformCamera[0].rotation;
            }
            else if (_configuration.basketballData.stateThrowBall[_configuration.levelBall] == 2)
            {
                _configuration.camera.transform.position = _configuration.transformCamera[1].position;
                _configuration.camera.transform.rotation = _configuration.transformCamera[1].rotation;
            }
            else if (_configuration.basketballData.stateThrowBall[_configuration.levelBall] == 3)
            {
                _configuration.camera.transform.position = _configuration.transformCamera[2].position;
                _configuration.camera.transform.rotation = _configuration.transformCamera[2].rotation;
            }

            _configuration.targetGoal = _configuration.basketballData.targetGoal[_configuration.levelBall];
        }
    }
}