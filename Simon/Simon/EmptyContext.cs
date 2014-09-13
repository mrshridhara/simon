namespace Simon
{
    /// <summary>
    /// Represents an null object pattern implementaion.
    /// </summary>
    public sealed class EmptyContext
    {
        private EmptyContext()
        {
        }

        static EmptyContext()
        {
        }

        /// <summary>
        /// Gets the instance of <see cref="EmptyContext"/> class.
        /// </summary>
        public static readonly EmptyContext Instance = new EmptyContext();
    }
}