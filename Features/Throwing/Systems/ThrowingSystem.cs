using Features._Shared.Components;
using Features.Fireballs.Components;
using Features.Throwing.Components;
using Leopotam.Ecs;
using Views.Custom;

namespace Features.Throwing.Systems
{
    public class ThrowingSystem : IEcsRunSystem
    {
        private readonly
            EcsFilter<ViewBackRef<IPlayerView>, ProjectileData, ThrowingCooldownData, ThrowingDirectionData,
                PointerUpEvent> _filter = default;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var cooldownData = ref _filter.Get3(i);
                if (cooldownData.RemainingTime > 0f) continue;

                ref var projectileData = ref _filter.Get2(i);
                var throwFrom = projectileData.ThrowFrom;
                var fireballEntity = _filter.Get1(i).View.Throw(throwFrom.position, throwFrom.rotation);

                var direction = _filter.Get4(i).Direction;
                ref var fireballData = ref fireballEntity.Get<FireballData>();
                fireballData.Direction = direction;
                fireballData.Speed = projectileData.ProjectileSpeed;
                fireballEntity.Replace(new LifetimeData { RemainingTime = projectileData.Lifetime });
                cooldownData.RemainingTime = cooldownData.Cooldown;
            }
        }
    }
}