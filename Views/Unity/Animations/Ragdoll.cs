using UnityEngine;

namespace Views.Unity.Animations
{
    public sealed class Ragdoll : MonoBehaviour
    {
        [SerializeField] private Animator _animator = default;
        [SerializeField] private Collider[] _mainColliders = default;
        [SerializeField] private Rigidbody _mainBody = default;

        public void Enable(Vector3 velocity)
        {
            _animator.enabled = false;

            foreach (var mainCollider in _mainColliders)
            {
                mainCollider.enabled = false;
            }

            SetAllKinematic(false);

            _mainBody.velocity = velocity;
        }

        private void SetAllKinematic(bool kinematic)
        {
            foreach (var rb in _rigidbodies)
            {
                rb.isKinematic = kinematic;
            }
        }

        private void Start()
        {
            SetAllKinematic(true);
        }

        private void Awake()
        {
            _rigidbodies = GetComponentsInChildren<Rigidbody>();
        }

        private Rigidbody[] _rigidbodies;
    }
}