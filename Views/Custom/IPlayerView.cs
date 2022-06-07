using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Views.Custom
{
    public interface IPlayerView : IView
    {
        Transform Trajectory { get; }
        EcsEntity Throw(Vector3 position, Quaternion rotation);
        void Die();
        event Action Died;
    }
}