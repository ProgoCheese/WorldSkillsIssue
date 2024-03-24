using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WorldSkillIssue
{
    public class AnalyticWinSystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        private EcsFilter<MenuLoseComponent> _filter;

        public void Run()
        {
            if (_sceneData.isWin == true)
            {
                _sceneData.numberLevel++;

                if (_sceneData.numberLevel > 4)
                {
                    _sceneData.isRandomLevel = true;
                }

                if (_sceneData.isRandomLevel)
                {
                    _sceneData.numberLevel = Random.Range(1,4);
                }
                SceneManager.LoadScene(2);
            }

            if (_sceneData.isLose == true)
            {
                //Debug.Log("dfass");
                _sceneData.isGameOn = false;
                foreach(var i in _filter)
                {
                    ref var menuData = ref _filter.Get1(i);
                    menuData.menu.SetActive(true);
                }
            }
        }
    }
}