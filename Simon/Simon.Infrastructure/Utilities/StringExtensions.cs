using System;
using System.Text;

namespace Simon.Infrastructure.Utilities
{
    /// <summary>
    ///
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Decodes the specified <paramref name="encodedString"/>.
        /// </summary>
        /// <param name="encodedString">The encoded string.</param>
        /// <returns>Decoded string.</returns>
        public static string ToDecodedBase64String(this string encodedString)
        {
            var data = Convert.FromBase64String(encodedString);
            return Encoding.UTF8.GetString(data);
        }

        /// <summary>
        /// Encodes the specified <paramref name="decodedString"/>.
        /// </summary>
        /// <param name="decodedString">The encoded string.</param>
        /// <returns>Encoded string.</returns>
        public static string ToEncodedBase64String(this string decodedString)
        {
            var charArray = decodedString.ToString().ToCharArray();
            var data = Encoding.UTF8.GetBytes(charArray);
            return Convert.ToBase64String(data);
        }
    }
}