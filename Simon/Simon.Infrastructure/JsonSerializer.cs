using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Represents a JSON serializer.
    /// </summary>
    public sealed class JsonSerializer : ISerializer
    {
        /// <summary>
        /// Serializes the data to string.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <typeparam name="TData">The type of data.</typeparam>
        /// <returns>The serialized string.</returns>
        public async Task<string> SerializeAsync<TData>(TData data)
        {
            return await Task.Run(() =>
            {
                return JsonConvert.SerializeObject(data);
            });
        }

        /// <summary>
        /// De-serializes the data from string to instance.
        /// </summary>
        /// <param name="serializedData">The serialized data.</param>
        /// <typeparam name="TData">The type of data.</typeparam>
        /// <returns>The instance of type <typeparamref name="TData"/>.</returns>
        public async Task<TData> DeserializeAsync<TData>(string serializedData)
        {
            return await Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<TData>(serializedData);
            });
        }
    }
}