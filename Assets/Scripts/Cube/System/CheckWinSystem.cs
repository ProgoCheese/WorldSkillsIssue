using Leopotam.Ecs;
using TMPro;

namespace WorldSkillIssue
{
    public class CheckWinSystem : IEcsRunSystem
    {
        private SceneData _sceneData;

        public void Run()
        {
            if (_sceneData.fieldFull == _sceneData.needFull)
            {
                _sceneData.isWin = true;
            }
        }
    }
}