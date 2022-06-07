using System;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using Views.Unity.Custom;

namespace Views.Unity.Animations
{
    public class ThrowAnimation : MonoBehaviour
    {
        private const int LayerIndex = 1;
        private static readonly int ThrowId = Animator.StringToHash("Throw");
        [SerializeField] [Min(0f)] private float _weightIncreaseTime = 0.1f;
        [SerializeField] [Min(0f)] private float _weightStillTime = 0.25f;
        [SerializeField] [Min(0f)] private float _weightDecreaseTime = 0.1f;
        private Animator _animator;
        private TweenCallback _onComplete;

        private Action _onThrew;
        private Sequence _sequence;
        private PlayerUnityView _view;
        private DOGetter<float> _weightGetter;
        private DOSetter<float> _weightSetter;

        private void Awake()
        {
            _onComplete = () => _sequence = null;
            _weightGetter = () => _animator.GetLayerWeight(LayerIndex);
            _weightSetter = value => _animator.SetLayerWeight(LayerIndex, value);

            _onThrew = () =>
            {
                _animator.SetTrigger(ThrowId);
                _sequence?.Kill();
                _sequence = DOTween.Sequence()
                    .Append(DOTween.To(_weightGetter, _weightSetter, 1f, _weightIncreaseTime))
                    .AppendInterval(_weightStillTime)
                    .Append(DOTween.To(_weightGetter, _weightSetter, 0f, _weightDecreaseTime))
                    .OnComplete(_onComplete);
            };
        }

        private void OnEnable()
        {
            _view.Threw += _onThrew;
        }

        private void OnDisable()
        {
            _view.Threw -= _onThrew;
        }

        public void Construct(PlayerUnityView view, Animator animator)
        {
            _view = view;
            _animator = animator;
        }
    }
}