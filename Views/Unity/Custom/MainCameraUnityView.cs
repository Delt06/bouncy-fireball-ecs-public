using Features._Shared.Components;
using Features.Movement.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Views.Unity.Custom
{
    public class MainCameraUnityView : UnityView
    {
        [SerializeField] private Transform _followTarget;

        protected override void AddComponents(EcsEntity entity)
        {
            entity.Replace(new TransformData { Transform = transform })
                .Replace(new CameraFollowData { Target = _followTarget });
        }
    }
}