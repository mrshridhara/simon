using System.Threading.Tasks;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines a serializer.
    /// </summary>
    /// <typeparam name="TData">The type of data.</typeparam>
    public interface ISerializer<TData>
    {
        /// <summary>
        /// Serializes the data to string.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The serialized string.</returns>
        Task<string> SerializeAsync(TData data);

        /// <summary>
        /// Deserializes the data from string to instance.
        /// </summary>
        /// <param name="serializedData">The serialized data.</param>
        /// <returns>The deserialized instance.</returns>
        Task<TData> DeserializeAsync(string serializedData);
    }
}