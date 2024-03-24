using Leopotam.Ecs;
using UnityEngine;

namespace WorldSkillIssue
{
    internal class InputClickSystem : IEcsRunSystem
    {
        private SceneData _sceneData;

        public void Run()
        {
            if (_sceneData.isGameOn == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var camera = Camera.main;
                    var ray = camera.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out var hitInfo))
                    {
                        var cellView = hitInfo.collider.tag;
                        //Debug.Log(cellView);

                        if (cellView == "leftCell")
                        {
                            _sceneData.cubeType = InputCubeType.Left;
                        }
                        else if (cellView == "rigthCell")
                        {
                            _sceneData.cubeType = InputCubeType.Right;
                        }
                        else if (cellView == "topCell")
                        {
                            _sceneData.cubeType = InputCubeType.Top;
                        }
                        else if (cellView == "bottomCell")
                        {
                            _sceneData.cubeType = InputCubeType.Bottom;
                        }

                        //Debug.Log(_sceneData.cubeType);
                    }
                }
            }
        }
    }
}