using Features._Shared.Components;
using Features.Throwing.Components;
using Leopotam.Ecs;
using Views.Custom;

namespace Features.Throwing.Systems
{
    public class ThrowingDirectionViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ViewBackRef<IPlayerView>, ThrowingDirectionData, ThrowingCooldownData>
            _filter = default;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                var trajectory = _filter.Get1(i).View.Trajectory;
                ref var cooldownData = ref _filter.Get3(i);

                if (entity.Has<PointerHoldData>() && cooldownData.RemainingTime <= 0f)
                {
                    trajectory.gameObject.SetActive(true);
                    trajectory.forward = _filter.Get2(i).Direction;
                }
                else
                {
                    trajectory.gameObject.SetActive(false);
                }
            }
        }
    }
}