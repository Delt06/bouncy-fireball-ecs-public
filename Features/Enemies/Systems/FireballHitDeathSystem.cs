using Features._Shared.Components;
using Features.Enemies.Components;
using Leopotam.Ecs;
using UnityEngine;
using Views.Custom;

namespace Features.Enemies.Systems
{
    public class FireballHitDeathSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ViewBackRef<IEnemyView>, FireballHitEvent> _filter = default;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                ref var hitEvent = ref _filter.Get2(i);
                var directVelocity = hitEvent.FireballData.DirectExplosionForce * hitEvent.HitDirection;
                var sideSign = Random.value < 0.5f ? 1f : -1f;
                var sideVelocity = sideSign * hitEvent.FireballData.SideExplosionForce * Vector3.right;
                var velocity = directVelocity + sideVelocity;

                entity.Replace(new ExplosionData { Velocity = velocity });
                _filter.Get1(i).View.Destroy();
            }
        }
    }
}