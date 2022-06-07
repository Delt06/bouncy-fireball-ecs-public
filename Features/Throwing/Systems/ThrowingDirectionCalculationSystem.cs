using Features.Throwing.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Features.Throwing.Systems
{
    public class ThrowingDirectionCalculationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ProjectileData, PointerHoldData, ThrowingDirectionData> _filter = default;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var projectileData = ref _filter.Get1(i);
                ref var holdData = ref _filter.Get2(i);
                var angle = holdData.Offset.y * projectileData.AngleSensitivity;
                angle = Mathf.Clamp(angle, -projectileData.MaxAngle, projectileData.MaxAngle);
                var direction = Quaternion.Euler(angle, 0f, 0f) * Vector3.forward;

                ref var throwingDirectionData = ref _filter.Get3(i);
                throwingDirectionData.Direction = direction;
            }
        }
    }
}