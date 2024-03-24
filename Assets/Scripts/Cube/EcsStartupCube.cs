using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace WorldSkillIssue
{
    public class EcsStartupCube : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;

        public SceneData SceneData;
        public Image timerBg;
        public GameObject menuLose;
        public GameObject startMenu;

        void Start()
        {
            if (SceneData.isStartGame)
            {
                startMenu.SetActive(true);
                SceneData.isStartGame = false;
            }

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            var entityTimer = _world.NewEntity();
            entityTimer.Get<ImageTimerBgComponent>().bg = timerBg;
            entityTimer.Get<ImageTimerBgComponent>().timer = SceneData.timerCube;

            var entityMenuLose = _world.NewEntity();
            entityMenuLose.Get<MenuLoseComponent>().menu = menuLose;

            _systems
                .Add(new GameInitLevelJsonCubeSystem())
                .Add(new GameInitCubeSystem())
                .Add(new CreateFieldCubeEmptySystem())
                //.Add(new CreateFieldCubeOccupedSystem())
                .Add(new InputClickSystem())
                .Add(new LeftMovingCubeSystem())
                .Add(new RigthMovingCubeSystem())
                .Add(new TopMovingCubeSystem())
                .Add(new BottomMovingCubeSystem())
                .Add(new CubeColliderDetectedSystem())
                .Add(new CheckWinSystem())
                .Add(new TimerCubeSystem())
                .Add(new AnalyticWinSystem())
                .Inject(SceneData)

                .Init();

            SceneData.cubeType = InputCubeType.None;
            SceneData.isWin = false;
            SceneData.fieldFull = 0;
        }
        // Update is called once per frame
        void Update()
        {
            _systems.Run();
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }

        public void OnStartMenu()
        {
            SceneData.cubeType = InputCubeType.None;
            SceneData.numberLevel = 1;
            SceneData.isGameOn = true;
            SceneData.fieldFull = 0;
            SceneData.isLose = false;
            SceneData.isRandomLevel = false;
            SceneManager.LoadScene(2);
        }
    }
}
