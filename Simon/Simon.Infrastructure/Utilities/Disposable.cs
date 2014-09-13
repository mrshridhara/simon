using System;

namespace Simon.Infrastructure.Utilities
{
    /// <summary>
    /// Provides the best implementation of the <see cref="IDisposable"/> interface.
    /// This is an abstract class.
    /// </summary>
    public abstract class Disposable : IDisposable
    {
        private bool disposed = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// When implemented releases all the managed resources in the derived class.
        /// </summary>
        protected abstract void DisposeManaged();

        /// <summary>
        /// When implemented releases all the unmanaged resources in the derived class.
        /// </summary>
        protected abstract void DisposeUnmanaged();

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                DisposeManaged();
            }

            DisposeUnmanaged();

            disposed = true;
        }

        /// <summary>
        /// Destroys the instance of <see cref="Disposable"/> class.
        /// </summary>
        ~Disposable()
        {
            Dispose(false);
        }
    }
}