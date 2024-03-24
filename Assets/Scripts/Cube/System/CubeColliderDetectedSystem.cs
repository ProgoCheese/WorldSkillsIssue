using Leopotam.Ecs;
using UnityEngine;

namespace WorldSkillIssue
{
    internal class CubeColliderDetectedSystem : IEcsRunSystem
    {
        EcsFilter<CellOccupedComponent> _filter;
        SceneData _sceneData;

        public void Run()
        {
            if (_sceneData.isGameOn == true)
            {
                foreach (var i in _filter)
                {
                    ref var cellOccupiedData = ref _filter.Get1(i);
                    var collider = cellOccupiedData.collider;
                    if (collider == null)
                    {
                        return;
                    }
                    Collider[] hitColliders = Physics.OverlapBox(cellOccupiedData.cube.transform.position, cellOccupiedData.collider.bounds.size / 2f, cellOccupiedData.cube.transform.rotation);
                    foreach (var hit in hitColliders)
                    {
                        if (cellOccupiedData.cube.transform.position != hit.transform.position)
                        {
                            if (hit.tag == "cube" && hit.name != cellOccupiedData.collider.name)
                            {
                                //Debug.Log("sfg");
                                GameObject.Destroy(cellOccupiedData.cube);
                                _sceneData.isLose = true;
                            }
                            else if (hit.tag == "Coin")
                            {
                                GameObject.Destroy(hit.gameObject, 0.8f);

                                Vector3 targetPosition = new Vector3(hit.gameObject.transform.position.x, hit.gameObject.transform.position.y, hit.gameObject.transform.position.z - 10f);
                                hit.gameObject.transform.position = Vector3.MoveTowards(hit.gameObject.transform.position, targetPosition, 1 * Time.deltaTime);

                                Quaternion targetRot = Quaternion.Euler(4, 0, 4);
                                hit.gameObject.transform.rotation *= targetRot;

                                _sceneData.coinCounter++;
                                hit.tag = "CollectedCoin";

                                PlayerPrefs.SetInt("CoinCounter", _sceneData.coinCounter);
                                PlayerPrefs.Save();
                            }
                            else if (hit.tag == "CollectedCoin")
                            {
                                GameObject.Destroy(hit.gameObject, 0.8f);

                                Vector3 targetPosition = new Vector3(hit.gameObject.transform.position.x, hit.gameObject.transform.position.y, hit.gameObject.transform.position.z - 10f);
                                hit.gameObject.transform.position = Vector3.MoveTowards(hit.gameObject.transform.position, targetPosition, 1 * Time.deltaTime);

                                Quaternion targetRot = Quaternion.Euler(4, 0, 4);
                                hit.gameObject.transform.rotation *= targetRot;
                            }
                        }
                    }
                }
            }
        }
    }
}