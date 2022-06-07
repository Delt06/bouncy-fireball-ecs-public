using Features._Shared.Components;
using Features.Fireballs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Features.Fireballs.Systems
{
    public class FireballMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransformData, FireballData> _filter = default;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transformData = ref _filter.Get1(i);
                ref var fireballData = ref _filter.Get2(i);
                var deltaPosition = Time.deltaTime * fireballData.Speed * fireballData.Direction;
                transformData.Transform.Translate(deltaPosition, Space.World);
            }
        }
    }
}