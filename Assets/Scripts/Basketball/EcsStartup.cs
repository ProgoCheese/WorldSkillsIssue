using UnityEngine;
using Leopotam.Ecs;
using UnityEngine.UI;
using TMPro;

namespace WorldSkillIssue
{

    public class EcsStartup : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;

        public Configuration Configuration;
        public new Camera camera;

        public TextMeshProUGUI GoalCounter;
        public TextMeshProUGUI TimerText;
        public TextMeshProUGUI TargetBallText;
        public TextMeshProUGUI RecordsText;
        public TextMeshProUGUI LevelText;

        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            Configuration.levelBall = 0;
            Configuration.camera = camera;

            var entity = _world.NewEntity();
            entity.Get<DisplayTextComponent>();
            entity.Get<GoalCounterComponent>();
            entity.Get<TextComponent>().value = GoalCounter;

            var entityTimer = _world.NewEntity();
            entityTimer.Get<DisplayTextComponent>();
            entityTimer.Get<TimerTextComponent>();
            entityTimer.Get<TextComponent>().value = TimerText;

            var entityTarget = _world.NewEntity();
            entityTarget.Get<DisplayTextComponent>();
            entityTarget.Get<TargetComponent>();
            entityTarget.Get<TextComponent>().value = TargetBallText;

            var entityRecords = _world.NewEntity();
            entityRecords.Get<DisplayTextComponent>();
            entityRecords.Get<RecordsComponent>();
            entityRecords.Get<TextComponent>().value = RecordsText;

            var entityLevel = _world.NewEntity();
            entityLevel.Get<DisplayTextComponent>();
            entityLevel.Get<LevelTextComponent>();
            entityLevel.Get<TextComponent>().value = LevelText;

            _systems
                .Add(new GameInitSystem())
                .Add(new InputGameBallSystem())
                .Add(new BallThrowSystem())
                .Add(new MovementSystem()) 
                .Add(new ColliderDetectedSystem()) 
                .Add(new UpdateTextGoalSystem()) 
                .Add(new UpdateTextTimerSystem()) 
                .Add(new UpdateTextTargetSystem()) 
                .Add(new UpdateTextRecordsSystem()) 
                .Add(new UpdateTextLevelSystem()) 

                .Inject(Configuration)

                .Inject(new TextComponent { value = GoalCounter })
                .Inject(new TextComponent { value = TimerText })
                .Inject(new TextComponent { value = TargetBallText })
                .Inject(new TextComponent { value = RecordsText })
                .Inject(new TextComponent { value = LevelText })

                .Init();
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
    }
}
