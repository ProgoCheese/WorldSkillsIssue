using Leopotam.Ecs;
using UnityEngine;
using UnityEditor.VersionControl;
using static UnityEngine.EventSystems.EventTrigger;

namespace WorldSkillIssue
{
    internal class CreateFieldCubeEmptySystem : IEcsInitSystem
    {
        private EcsFilter<CellEmptyComponent> _filter;
        private SceneData _sceneData;

        public void Init()
        {
            foreach (var i in _filter)
            {
                ref var cellData = ref _filter.Get1(i);

                //aDebug.Log(new Vector3((0.1f + _sceneData.sizeCell) * cellData.x, (0.1f + _sceneData.sizeCell) * cellData.y, _sceneData.spawnPosition.position.z));

                //cellData.position.position = new Vector3((0.1f + _sceneData.sizeCell)*cellData.x, (0.1f + _sceneData.sizeCell) * cellData.y, _sceneData.spawnPosition.position.z);

                var cell = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cell.GetComponent<MeshRenderer>().material = _sceneData.material[0];
                cell.GetComponent<BoxCollider>().size = new Vector3(_sceneData.sizeCell, _sceneData.sizeCell, _sceneData.sizeCell + 0.5f);

                cell.transform.position = new Vector3((0.1f + _sceneData.sizeCell) * cellData.x, (0.1f + _sceneData.sizeCell) * cellData.y, _sceneData.spawnPosition.position.z);
                cell.transform.localScale = new Vector3(_sceneData.sizeCell, _sceneData.sizeCell, 0.2f);

                cellData.position = cell.transform;
                if (_sceneData.lenghtField == 6)
                {
                    if (cellData.x < 2 && (cellData.y > 1 && cellData.y < 4))
                    {
                        cell.tag = "leftCell";
                    }
                    else if (cellData.x > 3 && (cellData.y > 1 && cellData.y < 4))
                    {
                        cell.tag = "rigthCell";
                    }
                    else if (cellData.y > 3 && (cellData.x > 1 && cellData.x < 4))
                    {
                        cell.tag = "topCell";
                    }
                    else if (cellData.y < 2 && (cellData.x > 1 && cellData.x < 4))
                    {
                        cell.tag = "bottomCell";
                    }
                }
                else if (_sceneData.lenghtField == 9)
                {
                    if (cellData.x < 3 && (cellData.y > 2 && cellData.y < 6))
                    {
                        cell.tag = "leftCell";
                    }
                    else if (cellData.x > 5 && (cellData.y > 2 && cellData.y < 6))
                    {
                        cell.tag = "rigthCell";
                    }
                    else if (cellData.y > 3 && (cellData.x > 2 && cellData.x < 6))
                    {
                        cell.tag = "topCell";
                    }
                    else if (cellData.y < 5 && (cellData.x > 2 && cellData.x < 6))
                    {
                        cell.tag = "bottomCell";
                    }
                }
            }
        }
    }
}