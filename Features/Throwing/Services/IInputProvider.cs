using System;
using UnityEngine;

namespace Features.Throwing.Services
{
    public interface IInputProvider
    {
        event Action PointerDown;
        event Action PointerUp;
        Vector2 ViewportOffsetFromInitialPosition { get; }
    }
}