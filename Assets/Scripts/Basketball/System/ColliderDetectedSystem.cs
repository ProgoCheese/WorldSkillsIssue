using Leopotam.Ecs;
using UnityEngine;

namespace WorldSkillIssue
{
    public class ColliderDetectedSystem : IEcsRunSystem
    {
        private EcsFilter<InputDataComponent, MovementComponent> _filter;
        private Configuration _configuration;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var ball = ref _filter.GetEntity(i);

                ref var inputData = ref _filter.Get1(i);
                ref var moveData = ref _filter.Get2(i);

                Collider[] hitColliders = Physics.OverlapBox(inputData.transform.position, inputData.collider.bounds.size / 2f, inputData.transform.rotation);
                if (hitColliders != null)
                {
                    foreach (Collider collider in hitColliders)
                    {
                        if (collider.tag == "Basket")
                        {
                            _configuration.goalCounter += 1;

                            if (_configuration.goalCounter > _configuration.recordingGoal)
                            {
                                _configuration.recordingGoal = _configuration.goalCounter;
                            }

                            if(_configuration.goalCounter >= _configuration.targetGoal)
                            {
                                _configuration.goalCounter = 0;
                                _configuration.levelBall++;
                            }

                            if(_configuration.levelBall >= _configuration.spawnBall.Length)
                            {

                            }                          

                            GameObject particle = new GameObject("Particle");
                            ParticleSystem particleSystem = particle.AddComponent<ParticleSystem>();
                            var mainModule = particleSystem.main;
                            mainModule.startLifetime = 1f;
                            mainModule.startSpeed = 5f;
                            mainModule.startSize = 0.5f;
                            mainModule.startColor = Color.red;
                            particleSystem.Play();
                            GameObject.Destroy(particle, 2f);

                            if (_configuration.basketballData.stateThrowBall[_configuration.levelBall] == 1)
                            {
                                inputData.transform.position = _configuration.spawnBall[0].position;
                            }
                            else if (_configuration.basketballData.stateThrowBall[_configuration.levelBall] == 2)
                            {
                                inputData.transform.position = _configuration.spawnBall[1].position;
                            }
                            else if (_configuration.basketballData.stateThrowBall[_configuration.levelBall] == 3)
                            {
                                inputData.transform.position = _configuration.spawnBall[2].position;
                            }

                            moveData.rb.useGravity = false;
                            moveData.rb.isKinematic = true;
                            moveData.rb.isKinematic = false;

                            _configuration.isThrow = false;

                            ball.Del<FlyComponent>();

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
                        else if (collider.tag == "Wall")
                        {
                            inputData.transform.position = _configuration.spawnBall[_configuration.levelBall].transform.position;
                            moveData.rb.useGravity = false;
                            moveData.rb.isKinematic = true;
                            moveData.rb.isKinematic = false;
                            _configuration.isThrow = false;
                            ball.Del<FlyComponent>();
                        }
                    }
                }
            }
        }
    }
}