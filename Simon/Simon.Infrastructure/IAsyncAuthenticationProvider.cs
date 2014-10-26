using System.Security.Claims;
using System.Threading.Tasks;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines an authentication provider.
    /// </summary>
    public interface IAsyncAuthenticationProvider
    {
        /// <summary>
        /// Gets the authentication mode.
        /// </summary>
        string AuthenticationMode { get; }

        /// <summary>
        /// Authenticates the current logged in user.
        /// </summary>
        /// <param name="authenticationToken">The authentication token.</param>
        /// <returns>The identity instance.</returns>
        Task<ClaimsIdentity> AuthenticateAsync(string authenticationToken);
    }
}