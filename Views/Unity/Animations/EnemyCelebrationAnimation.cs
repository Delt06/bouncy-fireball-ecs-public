using System;
using DG.Tweening;
using UnityEngine;
using Views.Custom;
using Random = UnityEngine.Random;

namespace Views.Unity.Animations
{
    public class EnemyCelebrationAnimation : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _maxDelay = 1f;

        public void Construct(IEnemyView enemyView, Animator animator)
        {
            _enemyView = enemyView;
            _animator = animator;
        }

        private void OnEnable()
        {
            _enemyView.PlayerDied += _onPlayerDied;
        }

        private void OnDisable()
        {
            _enemyView.PlayerDied -= _onPlayerDied;
        }

        private void Awake()
        {
            _onPlayerDied = () => DOTween.Sequence()
                .AppendInterval(Random.Range(0f, _maxDelay))
                .AppendCallback(() => _animator.SetTrigger(CelebrateId));
        }

        private Action _onPlayerDied;
        private IEnemyView _enemyView;
        private Animator _animator;
        private static readonly int CelebrateId = Animator.StringToHash("Celebrate");
    }
}