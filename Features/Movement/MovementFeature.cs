using Features.Movement.Systems;
using JetBrains.Annotations;
using Leopotam.Ecs;

namespace Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature([NotNull] EcsSystems systems, [NotNull] EcsSystems physicsSystems) : base(systems,
            physicsSystems
        ) { }

        protected override void Add(EcsSystems systems, EcsSystems physicsSystems)
        {
            systems.Add(new RunningSystem())
                .Add(new CameraFollowSystem());
        }
    }
}