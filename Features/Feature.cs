using System;
using JetBrains.Annotations;
using Leopotam.Ecs;

namespace Features
{
    public abstract class Feature
    {
        protected Feature([NotNull] EcsSystems systems, [NotNull] EcsSystems physicsSystems)
        {
            _systems = systems ?? throw new ArgumentNullException(nameof(systems));
            _physicsSystems = physicsSystems ?? throw new ArgumentNullException(nameof(physicsSystems));
        }

        public void Add() => Add(_systems, _physicsSystems);

        protected abstract void Add(EcsSystems systems, EcsSystems physicsSystems);

        private readonly EcsSystems _systems;
        private readonly EcsSystems _physicsSystems;
    }
}