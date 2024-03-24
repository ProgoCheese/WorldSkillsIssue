using Leopotam.Ecs;
using UnityEngine;

namespace WorldSkillIssue
{
    internal class GameInitCubeSystem : IEcsInitSystem
    {
        private SceneData _sceneData;
        private EcsWorld _world;

        public void Init()
        {
            for (int x = 0; x < _sceneData.lenghtField; x++)
            {
                for (int y = 0; y < _sceneData.lenghtField; y++)
                {
                    if (_sceneData.gameField[x, y] != 0)
                    {
                        var entity = _world.NewEntity();

                        ref var cellData = ref entity.Get<CellEmptyComponent>();

                        cellData.y = y;
                        cellData.x = x;

                        if (_sceneData.gameField[x, y] == 2)
                        {
                            var cell = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            cell.GetComponent<MeshRenderer>().material = _sceneData.skinCube[_sceneData.indexSkin];

                            cell.transform.position = new Vector3((0.1f + _sceneData.sizeCell) * x, (0.1f + _sceneData.sizeCell) * y, _sceneData.spawnPosition.position.z);
                            cell.transform.localScale = new Vector3(_sceneData.sizeCell - 0.2f, _sceneData.sizeCell - 0.2f, 0.4f);
                            entity.Get<CellOccupedComponent>().cube = cell;
                            entity.Get<CellOccupedComponent>().collider = cell.GetComponent<BoxCollider>();

                            cell.tag = "cube";

                            if (_sceneData.lenghtField == 6)
                            {
                                if (cellData.x < 2 && (cellData.y > 1 && cellData.y < 4))
                                {
                                    entity.Get<LeftCubeComponent>();
                                    cell.name = "cubeLeft"; 
                                }
                                else if (cellData.x > 3 && (cellData.y > 1 && cellData.y < 4))
                                {
                                    entity.Get<RigthCubeComponent>();
                                    cell.name = "cubeRigth";
                                }
                                else if (cellData.y > 3 && (cellData.x > 1 && cellData.x < 4))
                                {
                                    entity.Get<TopCubeComponent>();
                                    cell.name = "cubeTop";
                                }
                                else if (cellData.y < 2 && (cellData.x > 1 && cellData.x < 4))
                                {
                                    entity.Get<BottomCubeComponent>();
                                    cell.name = "cubeBottom";
                                }
                            }
                            else if (_sceneData.lenghtField == 9)
                            {
                                if (cellData.x < 3 && (cellData.y > 2 && cellData.y < 6))
                                {
                                    entity.Get<LeftCubeComponent>();
                                    cell.name = "cubeLeft";
                                }
                                else if (cellData.x > 5 && (cellData.y > 2 && cellData.y < 6))
                                {
                                    entity.Get<RigthCubeComponent>();
                                    cell.name = "cubeRigth";
                                }
                                else if (cellData.y > 3 && (cellData.x > 2 && cellData.x < 6))
                                {
                                    entity.Get<TopCubeComponent>();
                                    cell.name = "cubeTop";
                                }
                                else if (cellData.y < 5 && (cellData.x > 2 && cellData.x < 6))
                                {
                                    entity.Get<BottomCubeComponent>();
                                    cell.name = "cubeBottom";
                                }
                            }


                        }
                        else if (_sceneData.gameField[x, y] == 3)
                        {
                            entity.Get<CellMoneyComponent>();

                            var cell = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            cell.GetComponent<MeshRenderer>().material = _sceneData.material[1];

                            cell.transform.position = new Vector3((0.1f + _sceneData.sizeCell) * x, (0.1f + _sceneData.sizeCell) * y, _sceneData.spawnPosition.position.z);
                            cell.transform.localScale = new Vector3(_sceneData.sizeCell - 0.4f, _sceneData.sizeCell - 0.4f, 0.5f);
                            cell.tag = "Coin";
                        }
                    }
                }

            }
        }
    }
}