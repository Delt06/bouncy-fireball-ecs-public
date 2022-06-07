using Features._Shared.Components;
using Features.Enemies.Components;
using Leopotam.Ecs;
using Views;
using Views.Custom;

namespace Features.Enemies.Systems
{
    public class FireballHitDestructionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ViewBackRef<IFireballView>, FireballHitEvent> _filter = default;

        public void Run()
        {
            foreach (var i in _filter)
            {
                _filter.Get1(i).View.Destroy();
            }
        }
    }
}