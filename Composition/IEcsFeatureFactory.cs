using JetBrains.Annotations;
using Leopotam.Ecs;

namespace Composition
{
    public interface IEcsFeatureFactory
    {
        void AddFeatures([NotNull] EcsSystems systems, [NotNull] EcsSystems physicsSystems);
    }
}