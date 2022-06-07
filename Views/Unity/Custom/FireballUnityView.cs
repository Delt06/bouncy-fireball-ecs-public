using Features._Shared.Components;
using Features.Fireballs.Components;
using Leopotam.Ecs;
using UnityEngine;
using Views.Custom;

namespace Views.Unity.Custom
{
    public class FireballUnityView : UnityView, IFireballView
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.contactCount <= 0) return;

            var contact = other.GetContact(0);
            if (!contact.otherCollider.CompareTag("BounceOff")) return;

            Entity.Replace(new CollisionEvent { Normal = contact.normal });
        }

        protected override void AddComponents(EcsEntity entity)
        {
            entity
                .Replace(new ViewBackRef<IFireballView> { View = this })
                ;
        }
    }
}