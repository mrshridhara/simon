using Simon.Infrastructure.Utilities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Simon.Infrastructure.BasicAuthentication
{
    /// <summary>
    /// Represents the windows authentication provider.
    /// </summary>
    public class BasicAuthenticationProvider : IAuthenticationProvider
    {
        /// <summary>
        /// Gets the authentication mode.
        /// </summary>
        public string AuthenticationMode
        {
            get { return "Basic"; }
        }

        /// <summary>
        /// Authenticates the current logged in user.
        /// </summary>
        /// <param name="authenticationToken">The authentication token.</param>
        /// <returns>The identity instance.</returns>
        public async Task<ClaimsIdentity> AuthenticateAsync(string authenticationToken)
        {
            Guard.NotNullOrEmptyStringArgument("authenticationToken", authenticationToken);

            return await Task.Factory.StartNew(
                () => Authenticate(authenticationToken),
                TaskCreationOptions.LongRunning);
        }

        private ClaimsIdentity Authenticate(string authenticationToken)
        {
            var decodedString = authenticationToken.ToDecodedBase64String();
            var parts = decodedString.Split(':');

            var username = parts[0];
            var password = parts[1];

            return new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "default")
            }, this.AuthenticationMode);
        }
    }
}