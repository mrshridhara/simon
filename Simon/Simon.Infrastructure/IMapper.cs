namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines a mapper which copies data.
    /// </summary>
    /// <typeparam name="TFrom">The type of "from" instance.</typeparam>
    /// <typeparam name="TTo">The type of "to" instance.</typeparam>
    public interface IMapper<in TFrom, out TTo>
    {
        /// <summary>
        /// Copies the data from <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>
        /// The copied instance.
        /// </returns>
        TTo Map(TFrom instance);
    }
}