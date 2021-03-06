using Features.Throwing.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Composition
{
    public sealed class EcsEntryPoint : MonoBehaviour, IActiveEcsWorld
    {
        public EcsWorld World
        {
            get
            {
                EnsureInitialized();
                return _world;
            }
        }

        private void EnsureInitialized()
        {
            if (_initialized) return;

            _initialized = true;
            _world = new EcsWorld();

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
#endif

            _systems = new EcsSystems(_world, "Systems");
            _physicsSystems = new EcsSystems(_world, "Physics Systems");

            AddFeatures(_systems, _physicsSystems);
            Inject(_systems, _physicsSystems);

            _systems.ProcessInjects();
            _physicsSystems.ProcessInjects();

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_physicsSystems);
#endif
        }

        private void AddFeatures(EcsSystems systems, EcsSystems physicsSystems)
        {
            var factories = GetComponentsInChildren<IEcsFeatureFactory>();

            foreach (var factory in factories)
            {
                factory.AddFeatures(systems, physicsSystems);
            }
        }

        private void Inject(EcsSystems systems, EcsSystems physicsSystems)
        {
            var providers = GetComponentsInChildren<IEcsInjectionProvider>();

            foreach (var provider in providers)
            {
                provider.Inject(systems, physicsSystems);
            }
        }

        private void Start()
        {
            EnsureInitialized();

            _systems.Init();
            _physicsSystems.Init();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void FixedUpdate()
        {
            _physicsSystems.Run();
        }

        private void OnDestroy()
        {
            _systems?.Destroy();
            _physicsSystems?.Destroy();
            _world?.Destroy();
        }

        private bool _initialized;
        private EcsSystems _systems;
        private EcsSystems _physicsSystems;
        private EcsWorld _world;
    }
}