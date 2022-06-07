using Features.Enemies.Components;
using Features.Enemies.Systems;
using JetBrains.Annotations;
using Leopotam.Ecs;

namespace Features.Enemies
{
    public class EnemiesFeature : Feature
    {
        public EnemiesFeature([NotNull] EcsSystems systems, [NotNull] EcsSystems physicsSystems) : base(systems,
            physicsSystems
        ) { }

        protected override void Add(EcsSystems systems, EcsSystems physicsSystems)
        {
            systems
                .Add(new FireballHitDestructionSystem())
                .Add(new FireballHitDeathSystem())
                .Add(new PlayerDeathOnEnemyHitSystem())
                .Add(new EnemyStopOnHitSystem())
                .OneFrame<FireballHitEvent>()
                .OneFrame<EnemyHitEvent>()
                ;
        }
    }
}