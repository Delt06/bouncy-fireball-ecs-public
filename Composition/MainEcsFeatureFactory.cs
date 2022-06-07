using System;
using Features.Enemies;
using Features.Enemies.Systems;
using Features.Fireballs;
using Features.Movement;
using Features.Throwing;
using Leopotam.Ecs;
using UnityEngine;

namespace Composition
{
    public sealed class MainEcsFeatureFactory : MonoBehaviour, IEcsFeatureFactory
    {
        public void AddFeatures(EcsSystems systems, EcsSystems physicsSystems)
        {
            if (systems == null) throw new ArgumentNullException(nameof(systems));
            if (physicsSystems == null) throw new ArgumentNullException(nameof(physicsSystems));

            new MovementFeature(systems, physicsSystems).Add();
            new ThrowingFeature(systems, physicsSystems).Add();
            new FireballsFeature(systems, physicsSystems).Add();
            new EnemiesFeature(systems, physicsSystems).Add();
        }
    }
}