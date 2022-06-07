using Features._Shared.Components;
using Features.Movement.Components;
using Leopotam.Ecs;

namespace Features.Movement.Systems
{
    public class CameraFollowSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<TransformData, CameraFollowData> _filter = default;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var transformData = _filter.Get1(i);
                ref var followData = ref _filter.Get2(i);
                transformData.Transform.position = followData.Target.position + followData.Offset;
            }
        }

        public void Init()
        {
            foreach (var i in _filter)
            {
                var transformData = _filter.Get1(i);
                ref var followData = ref _filter.Get2(i);
                followData.Offset = transformData.Transform.position - followData.Target.position;
            }
        }
    }
}