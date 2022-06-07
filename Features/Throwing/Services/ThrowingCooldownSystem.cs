using Features.Throwing.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Features.Throwing.Services
{
    public class ThrowingCooldownSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ThrowingCooldownData> _filter = default;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var cooldownData = ref _filter.Get1(i);
                if (cooldownData.RemainingTime < 0f) continue;

                cooldownData.RemainingTime -= Time.deltaTime;
            }
        }
    }
}