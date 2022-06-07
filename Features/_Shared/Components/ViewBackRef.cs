using Views;

namespace Features._Shared.Components
{
    public struct ViewBackRef<TView> where TView : IView
    {
        public TView View;
    }
}