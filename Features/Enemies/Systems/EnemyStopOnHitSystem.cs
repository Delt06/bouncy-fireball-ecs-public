using Features._Shared.Components;
using Features.Enemies.Components;
using Features.Movement.Components;
using Leopotam.Ecs;
using Views.Custom;

namespace Features.Enemies.Systems
{
    public class EnemyStopOnHitSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EnemyTag, EnemyHitEvent> _hitEventFilter = default;
        private readonly EcsFilter<ViewBackRef<IEnemyView>, EnemyTag, RunningData> _enemiesFilter = default;

        public void Run()
        {
            if (_hitEventFilter.GetEntitiesCount() == 0) return;

            foreach (var i in _enemiesFilter)
            {
                _enemiesFilter.GetEntity(i).Del<RunningData>();
                _enemiesFilter.Get1(i).View.OnPlayerDied();
            }
        }
    }
}