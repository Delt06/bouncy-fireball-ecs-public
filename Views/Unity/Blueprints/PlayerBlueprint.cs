using Extensions.Blueprints;
using Features.Movement.Components;
using Features.Throwing.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Views.Unity.Blueprints
{
    [CreateAssetMenu(menuName = AssetPath + "Player")]
    public class PlayerBlueprint : EntityBlueprint
    {
        [Header("Movement")]
        [SerializeField] private Vector3 _velocity = Vector3.forward;

        [Header("Throwing")]
        [SerializeField] [Min(0f)] private float _throwingCooldown = 1f;

        [SerializeField] [Min(0f)] private float _throwingAngleSensitivity = 10f;
        [SerializeField] [Min(0f)] private float _throwingMaxAngle = 30f;

        [Header("Throwing.Projectile")]
        [SerializeField] [Min(0f)] private float _projectileLifetime = 1f;
        [SerializeField] [Min(0f)] private float _projectileSpeed = 1f;

        public override void InitializeEntity(EcsEntity entity)
        {
            entity
                .Replace(new RunningData { Velocity = _velocity })
                .Replace(new ProjectileData
                    {
                        ProjectileSpeed = _projectileSpeed,
                        AngleSensitivity = _throwingAngleSensitivity,
                        MaxAngle = _throwingMaxAngle,
                        Lifetime = _projectileLifetime,
                    }
                )
                .Replace(new ThrowingDirectionData())
                .Replace(new ThrowingCooldownData { Cooldown = _throwingCooldown, RemainingTime = 0f })
                ;
        }
    }
}