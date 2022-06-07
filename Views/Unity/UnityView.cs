using Extensions.Blueprints;
using Features._Shared.Components;
using Features.Throwing.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Views.Unity
{
    public abstract class UnityView : MonoBehaviour, IView
    {
        [SerializeField] private EntityBlueprint _blueprint;
        private IActiveEcsWorld _activeWorld;

        private EcsEntity _entity = EcsEntity.Null;

        public EcsEntity Entity => _entity;

        public virtual void Destroy() => Destroy(gameObject);

        protected void Awake()
        {
            _entity = _activeWorld.World.NewEntity();
            _entity.Replace(new TransformData { Transform = transform });

            if (_blueprint)
                _blueprint.InitializeEntity(_entity);

            AddComponents(_entity);
        }

        protected void OnDestroy()
        {
            if (_entity.IsNull()) return;
            if (!_entity.IsAlive()) return;
            if (!_entity.IsWorldAlive()) return;

            _entity.Destroy();
            _entity = EcsEntity.Null;
        }

        public void Construct(IActiveEcsWorld activeWorld)
        {
            _activeWorld = activeWorld;
        }

        protected virtual void AddComponents(EcsEntity entity) { }
    }
}