using Leopotam.Ecs;

namespace WorldSkillIssue
{
    internal class GameInitLevelJsonCubeSystem : IEcsInitSystem
    {
        private SceneData _sceneData;
        public void Init()
        {
            var levelData = _sceneData.LevelGameCube[_sceneData.numberLevel-1];
            _sceneData.gameField = levelData.gameField;
            _sceneData.needFull = levelData.needFull;
            _sceneData.lenghtField = levelData.lenghtField;
        }
    }
}