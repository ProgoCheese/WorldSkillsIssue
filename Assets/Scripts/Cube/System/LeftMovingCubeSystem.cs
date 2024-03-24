using Leopotam.Ecs;
using System.Transactions;
using UnityEngine;

namespace WorldSkillIssue
{
    internal class LeftMovingCubeSystem : IEcsRunSystem
    {
        private EcsFilter<CellEmptyComponent, CellOccupedComponent, LeftCubeComponent> _filter;
        private SceneData _sceneData;
        private bool isFirst = false;
        private bool isLast = false;

        public void Run()
        {
            if (_sceneData.cubeType == InputCubeType.Left || isFirst)
            {
                foreach (var i in _filter)
                {
                    ref var cellData = ref _filter.Get1(i);
                    ref var cubeData = ref _filter.Get2(i);
                    if (cubeData.cube != null)
                    {
                        int cellGo = _sceneData.lenghtField / 3;
                        Vector3 targetPosition = new Vector3(cellData.position.position.x + cellGo * (_sceneData.sizeCell + 0.1f) + 3f, cellData.position.position.y, cubeData.cube.transform.position.z);

                        if (cubeData.cube.transform.position.x < cellData.position.position.x + cellGo * (_sceneData.sizeCell + 0.1f))
                        {
                            cubeData.cube.transform.position = Vector3.Lerp(cubeData.cube.transform.position, targetPosition, _sceneData.speedCube * Time.deltaTime);
                        }

                        if (cubeData.cube.transform.position.x >= cellData.position.position.x + cellGo * (_sceneData.sizeCell + 0.1f) && !isLast)
                        {
                            isLast = true;
                            _sceneData.fieldFull++;
                        }

                        isFirst = true;
                    }
                }
            }
        }
    }
}