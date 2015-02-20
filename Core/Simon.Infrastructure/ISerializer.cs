using System.Threading.Tasks;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines a serializer.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// De-serializes the data from string to instance.
        /// </summary>
        /// <param name="serializedData">The serialized data.</param>
        /// <typeparam name="TData">The type of data.</typeparam>
        /// <returns>The instance of type <typeparamref name="TData"/>.</returns>
        Task<TData> DeserializeAsync<TData>(string serializedData);

        /// <summary>
        /// Serializes the data to string.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <typeparam name="TData">The type of data.</typeparam>
        /// <returns>The serialized string.</returns>
        Task<string> SerializeAsync<TData>(TData data);
    }
}