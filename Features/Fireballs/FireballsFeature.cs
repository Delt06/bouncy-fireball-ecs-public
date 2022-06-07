using Features.Fireballs.Components;
using Features.Fireballs.Systems;
using JetBrains.Annotations;
using Leopotam.Ecs;

namespace Features.Fireballs
{
    public sealed class FireballsFeature : Feature
    {
        public FireballsFeature([NotNull] EcsSystems systems, [NotNull] EcsSystems physicsSystems) : base(systems,
            physicsSystems
        ) { }

        protected override void Add(EcsSystems systems, EcsSystems physicsSystems)
        {
            systems
                .Add(new FireballLifetimeSystem())
                .Add(new FireballMovementSystem())
                .Add(new FireballBounceSystem())
                .OneFrame<CollisionEvent>()
                ;
        }
    }
}