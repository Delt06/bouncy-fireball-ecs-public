using Features._Shared.Components;
using Features.Movement.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Features.Movement.Systems
{
    public class RunningSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransformData, RunningData> _filter = default;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var transformData = _filter.Get1(i);
                var runningData = _filter.Get2(i);
                var movementDelta = runningData.Velocity * Time.deltaTime;
                transformData.Transform.Translate(movementDelta, Space.World);
            }
        }
    }
}