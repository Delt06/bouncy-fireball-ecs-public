using Leopotam.Ecs;
using UnityEngine;

namespace Extensions.Blueprints
{
    public abstract class EntityBlueprint : ScriptableObject
    {
        public abstract void InitializeEntity(EcsEntity entity);

        protected const string AssetPath = "Entity Blueprint/";
    }
}