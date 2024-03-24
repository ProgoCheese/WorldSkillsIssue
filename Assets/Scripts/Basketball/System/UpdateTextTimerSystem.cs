using Leopotam.Ecs;
using UnityEngine;

namespace WorldSkillIssue
{
    internal class UpdateTextTimerSystem : IEcsRunSystem
    {
        private EcsFilter<TextComponent, DisplayTextComponent, TimerTextComponent> _filter;
        private Configuration _configuration;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var textComponent = ref _filter.Get1(i);
                ref var displayTextComponent = ref _filter.Get2(i);

                displayTextComponent.text = "Время:...";
                textComponent.value.text = displayTextComponent.text;
                //Debug.Log(displayTextComponent.text);
            }
        }
    }
}