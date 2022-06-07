using System;
using Features._Shared.Components;
using Features.Throwing.Components;
using Leopotam.Ecs;
using UnityEngine;
using Views.Custom;

namespace Views.Unity.Custom
{
    public class PlayerUnityView : UnityView, IPlayerView
    {
        [SerializeField] private Transform _throwFrom = default;
        [SerializeField] private FireballUnityView _fireballPrefab = default;
        [SerializeField] private Transform _trajectory = default;

        public Transform Trajectory => _trajectory;

        public EcsEntity Throw(Vector3 position, Quaternion rotation)
        {
            var entity = Instantiate(_fireballPrefab, position, rotation).Entity;
            Threw?.Invoke();
            return entity;
        }

        public event Action Threw;

        public void Die()
        {
            Entity.Destroy();
            Died?.Invoke();
        }

        public event Action Died;

        protected override void AddComponents(EcsEntity entity)
        {
            entity
                .Replace(new ViewBackRef<IPlayerView> { View = this })
                ;

            ref var projectileData = ref entity.Get<ProjectileData>();
            projectileData.ThrowFrom = _throwFrom;
        }
    }
}