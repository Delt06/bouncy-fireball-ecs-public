using UnityEngine;

namespace Features.Throwing.Components
{
    public struct ProjectileData
    {
        public Transform ThrowFrom;
        public float AngleSensitivity;
        public float MaxAngle;
        public float ProjectileSpeed;
        public float Lifetime;
    }
}