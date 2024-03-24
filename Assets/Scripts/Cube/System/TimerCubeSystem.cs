using Leopotam.Ecs;
using UnityEngine;

namespace WorldSkillIssue
{
    internal class TimerCubeSystem : IEcsRunSystem
    {
        private EcsFilter<ImageTimerBgComponent> _filter;
        private SceneData _sceneData;

        public void Run()
        {
            if (_sceneData.isGameOn == true)
            {
                foreach (var i in _filter)
                {
                    ref var imageData = ref _filter.Get1(i);
                    imageData.timer -= Time.deltaTime;
                    imageData.bg.fillAmount = Mathf.InverseLerp(0, (int)_sceneData.timerCube, (int)imageData.timer);
                }
            }
        }
    }
}