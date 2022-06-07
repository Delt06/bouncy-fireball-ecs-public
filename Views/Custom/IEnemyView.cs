using System;

namespace Views.Custom
{
    public interface IEnemyView : IView
    {
        void OnPlayerDied();
        event Action PlayerDied;
    }
}