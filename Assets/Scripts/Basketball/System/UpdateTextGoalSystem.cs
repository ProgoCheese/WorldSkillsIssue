using Leopotam.Ecs;

namespace WorldSkillIssue
{
    public class UpdateTextGoalSystem : IEcsRunSystem
    {
        private EcsFilter<TextComponent, DisplayTextComponent, GoalCounterComponent> _filter;
        private Configuration _configuration;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var textComponent = ref _filter.Get1(i);
                ref var displayTextComponent = ref _filter.Get2(i);

                displayTextComponent.text = "Счет: " + (_configuration.goalCounter);
                textComponent.value.text = displayTextComponent.text;
            }
        }
    }
}