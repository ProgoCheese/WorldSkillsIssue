using Leopotam.Ecs;

namespace WorldSkillIssue
{
    internal class UpdateTextLevelSystem : IEcsRunSystem
    {
        private EcsFilter<TextComponent, DisplayTextComponent, LevelTextComponent> _filter;
        private Configuration _configuration;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var textComponent = ref _filter.Get1(i);
                ref var displayTextComponent = ref _filter.Get2(i);

                displayTextComponent.text = "уровень: " + (_configuration.goalCounter);
                textComponent.value.text = displayTextComponent.text;
            }
        }
    }
}