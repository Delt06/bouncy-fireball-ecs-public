using Features.Fireballs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Features.Fireballs.Systems
{
    public class FireballBounceSystem : IEcsRunSystem
    {
        private readonly EcsFilter<FireballData, CollisionEvent> _filter = default;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var fireballData = ref _filter.Get1(i);
                var normal = _filter.Get2(i).Normal;
                var newDirection = Vector3.Reflect(fireballData.Direction, normal);
                fireballData.Direction = newDirection;
            }
        }
    }
}