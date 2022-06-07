using Extensions.Blueprints;
using Features.Enemies.Components;
using Features.Movement.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Views.Unity.Blueprints
{
    [CreateAssetMenu(menuName = AssetPath + "Enemy")]
    public class EnemyBlueprint : EntityBlueprint
    {
        [Header("Movement")]
        [SerializeField] [Min(0f)] private Vector3 _velocity = Vector3.back;

        public override void InitializeEntity(EcsEntity entity)
        {
            entity.Replace(new RunningData { Velocity = _velocity })
                .Replace(new EnemyTag());
        }
    }
}