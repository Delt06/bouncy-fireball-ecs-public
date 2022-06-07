using Extensions.Blueprints;
using Features.Fireballs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Views.Unity.Blueprints
{
    [CreateAssetMenu(menuName = AssetPath + "Fireball")]
    public class FireballBlueprint : EntityBlueprint
    {
        [SerializeField] [Min(0f)] private float _directExplosionForce = 1f;
        [SerializeField] [Min(0f)] private float _sideExplosionForce = 1f;

        public override void InitializeEntity(EcsEntity entity)
        {
            entity.Replace(new FireballData
                {
                    DirectExplosionForce = _directExplosionForce,
                    SideExplosionForce = _sideExplosionForce,
                }
            );
        }
    }
}