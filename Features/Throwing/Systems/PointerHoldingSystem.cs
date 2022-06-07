using Features.Throwing.Components;
using Features.Throwing.Services;
using Leopotam.Ecs;

namespace Features.Throwing.Systems
{
    public class PointerHoldingSystem : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private readonly IInputProvider _inputProvider = default;
        private readonly EcsFilter<ThrowingCooldownData> _potentialReceiversFilter = default;
        private readonly EcsFilter<PointerHoldData> _holdFilter = default;

        public void Run()
        {
            foreach (var i in _holdFilter)
            {
                ref var holdData = ref _holdFilter.Get1(i);
                holdData.Offset = _inputProvider.ViewportOffsetFromInitialPosition;
            }
        }

        public void Init()
        {
            _inputProvider.PointerUp += OnPointerUp;
            _inputProvider.PointerDown += OnPointerDown;
        }

        public void Destroy()
        {
            _inputProvider.PointerUp -= OnPointerUp;
            _inputProvider.PointerDown -= OnPointerDown;
        }

        private void OnPointerDown()
        {
            foreach (var i in _potentialReceiversFilter)
            {
                _potentialReceiversFilter.GetEntity(i).Replace(new PointerHoldData());
            }
        }

        private void OnPointerUp()
        {
            foreach (var i in _holdFilter)
            {
                ref var holdData = ref _holdFilter.Get1(i);
                var offset = holdData.Offset;

                ref var entity = ref _holdFilter.GetEntity(i);
                entity.Del<PointerHoldData>();
                entity.Replace(new PointerUpEvent { Offset = offset });
            }
        }
    }
}