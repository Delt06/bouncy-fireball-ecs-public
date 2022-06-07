using Leopotam.Ecs;

namespace Views
{
    public interface IView
    {
        EcsEntity Entity { get; }
        void Destroy();
    }
}