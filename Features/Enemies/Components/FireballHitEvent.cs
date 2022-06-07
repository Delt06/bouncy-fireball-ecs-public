using Features.Fireballs.Components;
using UnityEngine;

namespace Features.Enemies.Components
{
    public struct FireballHitEvent
    {
        public FireballData FireballData;
        public Vector3 HitDirection;
    }
}