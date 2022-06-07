using System;
using Features._Shared.Components;
using Features.Enemies.Components;
using Features.Fireballs.Components;
using Leopotam.Ecs;
using UnityEngine;
using Views.Custom;
using Views.Unity.Animations;

namespace Views.Unity.Custom
{
    public class EnemyUnityView : UnityView, IEnemyView
    {
        [SerializeField] [Min(0f)] private float _destructionDelay = 2f;

        public void Construct(Ragdoll ragdoll)
        {
            _ragdoll = ragdoll;
        }

        public override void Destroy()
        {
            var velocity = Entity.Get<ExplosionData>().Velocity;
            _ragdoll.Enable(velocity);

            Entity.Destroy();
            Destroy(gameObject, _destructionDelay);
        }

        public void OnPlayerDied()
        {
            PlayerDied?.Invoke();
        }

        public event Action PlayerDied;

        protected override void AddComponents(EcsEntity entity)
        {
            entity.Replace(new ViewBackRef<IEnemyView> { View = this });
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.contactCount == 0) return;

            var contact = other.GetContact(0);
            CheckCollisionWithFireball(other, contact);
            CheckCollisionWithPlayer(other);
        }

        private void CheckCollisionWithFireball(Collision other, ContactPoint contact)
        {
            if (!TryGetInOtherRigidbody(other, out IFireballView fireballView)) return;

            var direction = contact.normal;

            var hitEvent = new FireballHitEvent
            {
                FireballData = fireballView.Entity.Get<FireballData>(),
                HitDirection = direction,
            };
            Entity.Replace(hitEvent);
            fireballView.Entity.Replace(hitEvent);
        }

        private void CheckCollisionWithPlayer(Collision other)
        {
            if (!TryGetInOtherRigidbody(other, out IPlayerView playerView)) return;

            var hitEvent = new EnemyHitEvent();
            Entity.Replace(hitEvent);
            playerView.Entity.Replace(hitEvent);
        }

        private static bool TryGetInOtherRigidbody<T>(Collision other, out T component)
        {
            component = default;
            return other.rigidbody &&
                   other.rigidbody.TryGetComponent(out component);
        }

        private Ragdoll _ragdoll;
    }
}