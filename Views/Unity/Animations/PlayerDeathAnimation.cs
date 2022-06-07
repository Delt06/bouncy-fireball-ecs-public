using System;
using UnityEngine;
using Views.Custom;

namespace Views.Unity.Animations
{
    public class PlayerDeathAnimation : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _activateParticleSystem = default;
        [SerializeField] private ParticleSystem _deathParticleSystem = default;

        public void Construct(IPlayerView view, Animator animator)
        {
            _view = view;
            _animator = animator;
        }

        private void OnEnable()
        {
            _view.Died += _onDied;
        }

        private void OnDisable()
        {
            _view.Died -= _onDied;
        }

        private void Awake()
        {
            _onDied = () =>
            {
                _animator.SetTrigger(DeathId);
                _activateParticleSystem.Stop();
                _deathParticleSystem.Play();
            };
        }

        private IPlayerView _view;
        private Action _onDied;
        private Animator _animator;
        private static readonly int DeathId = Animator.StringToHash("Death");
    }
}