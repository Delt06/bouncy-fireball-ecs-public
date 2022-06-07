using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Features.Throwing.Services
{
    public class UIInputProvider : MonoBehaviour, IInputProvider, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public event Action PointerDown;
        public event Action PointerUp;

        public Vector2 ViewportOffsetFromInitialPosition { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_pointerId != null) return;
            _initialPosition = eventData.position;
            _pointerId = eventData.pointerId;
            PointerDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_pointerId != eventData.pointerId) return;
            _pointerId = null;
            PointerUp?.Invoke();
            ViewportOffsetFromInitialPosition = Vector2.zero;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_pointerId != eventData.pointerId) return;
            var offset = eventData.position - _initialPosition;
            ViewportOffsetFromInitialPosition = _camera.ScreenToViewportPoint(offset);
        }

        private void Awake()
        {
            _camera = Camera.main;
        }

        private Camera _camera;
        private int? _pointerId;
        private Vector2 _initialPosition;
    }
}