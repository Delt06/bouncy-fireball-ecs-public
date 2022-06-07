using Features._Shared.Components;
using Features.Fireballs.Components;
using Leopotam.Ecs;
using UnityEngine;
using Views;
using Views.Custom;

namespace Features.Fireballs.Systems
{
    public class FireballLifetimeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ViewBackRef<IFireballView>, LifetimeData> _filter = default;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var lifetimeData = ref _filter.Get2(i);
                lifetimeData.RemainingTime -= Time.deltaTime;
                if (lifetimeData.RemainingTime <= 0f)
                    _filter.Get1(i).View.Destroy();
            }
        }
    }
}