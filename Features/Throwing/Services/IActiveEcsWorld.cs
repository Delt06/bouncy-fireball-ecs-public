using Leopotam.Ecs;

namespace Features.Throwing.Services
{
    public interface IActiveEcsWorld
    {
        EcsWorld World { get; }
    }
}