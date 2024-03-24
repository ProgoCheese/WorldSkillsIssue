using Leopotam.Ecs;

namespace WorldSkillIssue
{
    internal class UpdateTextRecordsSystem : IEcsRunSystem
    {
        private EcsFilter<TextComponent, DisplayTextComponent, RecordsComponent> _filter;
        private Configuration _configuration;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var textComponent = ref _filter.Get1(i);
                ref var displayTextComponent = ref _filter.Get2(i);

                displayTextComponent.text = "Рекорд: " + (_configuration.recordingGoal);
                textComponent.value.text = displayTextComponent.text;
            }
        }
    }
}