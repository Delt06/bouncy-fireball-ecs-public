using System;
using Features._Shared.Services;
using Features.Throwing.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Composition
{
    public sealed class MainEcsInjectionProvider : MonoBehaviour, IEcsInjectionProvider
    {
        [SerializeField] private UIInputProvider _inputProvider = default;

        public void Inject(EcsSystems systems, EcsSystems physicsSystems)
        {
            if (systems == null) throw new ArgumentNullException(nameof(systems));
            if (physicsSystems == null) throw new ArgumentNullException(nameof(physicsSystems));

            systems.Inject(new UnityLogger());
            systems.Inject(_inputProvider);
        }
    }
}