using Features.Throwing.Components;
using Features.Throwing.Services;
using Features.Throwing.Systems;
using JetBrains.Annotations;
using Leopotam.Ecs;

namespace Features.Throwing
{
    public class ThrowingFeature : Feature
    {
        public ThrowingFeature([NotNull] EcsSystems systems, [NotNull] EcsSystems physicsSystems) : base(systems,
            physicsSystems
        ) { }

        protected override void Add(EcsSystems systems, EcsSystems physicsSystems)
        {
            systems
                .Add(new PointerHoldingSystem())
                .Add(new ThrowingCooldownSystem())
                .Add(new ThrowingDirectionCalculationSystem())
                .Add(new ThrowingDirectionViewSystem())
                .Add(new ThrowingSystem())
                .OneFrame<PointerUpEvent>();
        }
    }
}