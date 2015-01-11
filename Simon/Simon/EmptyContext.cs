namespace Simon
{
    /// <summary>
    /// Represents an null object pattern implementation.
    /// </summary>
    public sealed class EmptyContext
    {
        /// <summary>
        /// Gets the instance of <see cref="EmptyContext"/> class.
        /// </summary>
        public static readonly EmptyContext Instance = new EmptyContext();

        static EmptyContext()
        { }

        private EmptyContext()
        { }
    }
}