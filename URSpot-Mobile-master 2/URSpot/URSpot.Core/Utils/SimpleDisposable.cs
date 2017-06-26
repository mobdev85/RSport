using System;

namespace URSpot.Core.Utils
{
    internal class SimpleDisposable : IDisposable
    {
        private Action onDispose;

        public SimpleDisposable(Action onDispose)
        {
            this.onDispose = onDispose;
        }

        public void Dispose()
        {
            this.onDispose();
        }
    }
}